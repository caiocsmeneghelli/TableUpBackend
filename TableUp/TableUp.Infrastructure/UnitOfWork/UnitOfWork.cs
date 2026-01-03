using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using TableUp.Domain.Repositories;
using TableUp.Domain.UnitOfWork;
using TableUp.Infrastructure.Persistence;

namespace TableUp.Infrastructure.UnitOfWork
{
    public sealed class UnitOfWork : IUnitOfWork, IAsyncDisposable
    {
        private readonly TableUpDbContext _dbContext;
        private IDbContextTransaction? _currentTransaction;
        public UnitOfWork(TableUpDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (_currentTransaction is not null)
                return;

            _currentTransaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            if (_currentTransaction is null)
            {
                // No explicit transaction started; ensure changes are persisted.
                await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                return;
            }

            try
            {
                await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                await _currentTransaction.CommitAsync(cancellationToken).ConfigureAwait(false);
            }
            finally
            {
                await DisposeCurrentTransactionAsync().ConfigureAwait(false);
            }
        }

        public async Task RollbackAsync(CancellationToken cancellationToken = default)
        {
            if (_currentTransaction is null)
                return;

            try
            {
                await _currentTransaction.RollbackAsync(cancellationToken).ConfigureAwait(false);
            }
            finally
            {
                await DisposeCurrentTransactionAsync().ConfigureAwait(false);
            }
        }

        private async Task DisposeCurrentTransactionAsync()
        {
            if (_currentTransaction is null)
                return;

            await _currentTransaction.DisposeAsync().ConfigureAwait(false);
            _currentTransaction = null;
        }

        // Dispose only transaction resources; DbContext lifetime is typically managed by the DI container.
        public async ValueTask DisposeAsync()
        {
            if (_currentTransaction is not null)
            {
                await _currentTransaction.DisposeAsync().ConfigureAwait(false);
                _currentTransaction = null;
            }
            GC.SuppressFinalize(this);
        }
    }
}