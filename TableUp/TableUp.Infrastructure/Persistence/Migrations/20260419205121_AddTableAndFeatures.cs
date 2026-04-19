using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TableUp.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddTableAndFeatures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TableNumber",
                table: "OrderBills");

            migrationBuilder.AddColumn<int>(
                name: "StatusOrderItem",
                table: "OrderItems",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "TableGuid",
                table: "OrderBills",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Number = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedByGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedByGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Tables_Users_CreatedByGuid",
                        column: x => x.CreatedByGuid,
                        principalTable: "Users",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_Tables_Users_UpdatedByGuid",
                        column: x => x.UpdatedByGuid,
                        principalTable: "Users",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderBills_TableGuid",
                table: "OrderBills",
                column: "TableGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Tables_CreatedByGuid",
                table: "Tables",
                column: "CreatedByGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Tables_UpdatedByGuid",
                table: "Tables",
                column: "UpdatedByGuid");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderBills_Tables_TableGuid",
                table: "OrderBills",
                column: "TableGuid",
                principalTable: "Tables",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderBills_Tables_TableGuid",
                table: "OrderBills");

            migrationBuilder.DropTable(
                name: "Tables");

            migrationBuilder.DropIndex(
                name: "IX_OrderBills_TableGuid",
                table: "OrderBills");

            migrationBuilder.DropColumn(
                name: "StatusOrderItem",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "TableGuid",
                table: "OrderBills");

            migrationBuilder.AddColumn<string>(
                name: "TableNumber",
                table: "OrderBills",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }
    }
}
