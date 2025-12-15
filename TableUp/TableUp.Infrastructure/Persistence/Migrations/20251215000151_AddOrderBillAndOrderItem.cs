using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TableUp.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderBillAndOrderItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderBills",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    StatusOrderBill = table.Column<int>(type: "integer", nullable: false),
                    TableNumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedByGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedByGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderBills", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_OrderBills_Users_CreatedByGuid",
                        column: x => x.CreatedByGuid,
                        principalTable: "Users",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_OrderBills_Users_UpdatedByGuid",
                        column: x => x.UpdatedByGuid,
                        principalTable: "Users",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    MenuItemGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderBillGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedByGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedByGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_OrderItems_MenuItems_MenuItemGuid",
                        column: x => x.MenuItemGuid,
                        principalTable: "MenuItems",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_OrderItems_OrderBills_OrderBillGuid",
                        column: x => x.OrderBillGuid,
                        principalTable: "OrderBills",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_OrderItems_Users_CreatedByGuid",
                        column: x => x.CreatedByGuid,
                        principalTable: "Users",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_OrderItems_Users_UpdatedByGuid",
                        column: x => x.UpdatedByGuid,
                        principalTable: "Users",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderBills_CreatedByGuid",
                table: "OrderBills",
                column: "CreatedByGuid");

            migrationBuilder.CreateIndex(
                name: "IX_OrderBills_UpdatedByGuid",
                table: "OrderBills",
                column: "UpdatedByGuid");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_CreatedByGuid",
                table: "OrderItems",
                column: "CreatedByGuid");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_MenuItemGuid",
                table: "OrderItems",
                column: "MenuItemGuid");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderBillGuid",
                table: "OrderItems",
                column: "OrderBillGuid");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_UpdatedByGuid",
                table: "OrderItems",
                column: "UpdatedByGuid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "OrderBills");
        }
    }
}
