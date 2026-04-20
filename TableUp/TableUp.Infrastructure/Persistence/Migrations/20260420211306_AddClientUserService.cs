using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TableUp.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddClientUserService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var systemUserId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[]
                {
            "Guid",
            "Name",
            "Username",
            "Email",
            "PasswordHash",
            "Status",
            "CreatedAt",
            "UpdatedAt"
                },
                values: new object[]
                {
            systemUserId,
            "System Client User",
            "clientuser",
            "client@internal.local",
            "HASH_PLACEHOLDER",
            1, // ativo
            DateTime.UtcNow,
            DateTime.UtcNow
                }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "system"
            );
        }
    }
}
