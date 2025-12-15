using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableUp.Domain.Entities;

namespace TableUp.Infrastructure.Persistence
{
    public class TableUpDbContext(DbContextOptions<TableUpDbContext> options) : DbContext(options)
    {
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<MenuCategory> MenuCategories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OrderBill> OrderBills { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var userType = typeof(User);
            var baseEntityType = typeof(BaseEntity);

            foreach (var et in modelBuilder.Model.GetEntityTypes()
                         .Where(t => t.ClrType != null && baseEntityType.IsAssignableFrom(t.ClrType)))
            {
                var entity = modelBuilder.Entity(et.ClrType);

                // configure foreign keys and navigation to User for CreatedBy / UpdatedBy
                entity.HasOne(userType, "CreatedBy")
                      .WithMany()
                      .HasForeignKey("CreatedByGuid")
                      .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(userType, "UpdatedBy")
                      .WithMany()
                      .HasForeignKey("UpdatedByGuid")
                      .OnDelete(DeleteBehavior.NoAction);
            }


            modelBuilder.Entity<MenuCategory>(entity =>
            {
                entity.HasKey(e => e.Guid);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<MenuItem>(entity =>
            {
                entity.HasKey(e => e.Guid);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.Value).IsRequired().HasColumnType("decimal(18,2)");
                entity.HasOne(e => e.Category)
                      .WithMany()
                      .HasForeignKey(e => e.CategoryGuid)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Guid);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Username).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
                entity.Property(e => e.PasswordHash).IsRequired().HasMaxLength(200);
            });

            modelBuilder.Entity<OrderBill>(entity =>
            {
                entity.HasKey(e => e.Guid);
                entity.Property(e => e.TableNumber).IsRequired().HasMaxLength(20);
                entity.Property(e => e.Amount).IsRequired().HasColumnType("decimal(18,2)");
                entity.Property(e => e.StatusOrderBill).IsRequired();

                entity.HasMany(e => e.BillItems)
                      .WithOne(e => e.OrderBill)
                      .HasForeignKey(e => e.OrderBillGuid)
                      .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(e => e.Guid);
                entity.Property(e => e.Quantity).IsRequired();
                entity.HasOne(e => e.MenuItem)
                      .WithMany()
                      .HasForeignKey(e => e.MenuItemGuid)
                      .OnDelete(DeleteBehavior.NoAction);
            });
        }
    }
}
