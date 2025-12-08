using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TableUp.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddUserOnBaseEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CreatedByGuid",
                table: "MenuItems",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedByGuid",
                table: "MenuItems",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedByGuid",
                table: "MenuCategories",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedByGuid",
                table: "MenuCategories",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_CreatedByGuid",
                table: "MenuItems",
                column: "CreatedByGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_UpdatedByGuid",
                table: "MenuItems",
                column: "UpdatedByGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MenuCategories_CreatedByGuid",
                table: "MenuCategories",
                column: "CreatedByGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MenuCategories_UpdatedByGuid",
                table: "MenuCategories",
                column: "UpdatedByGuid");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuCategories_Users_CreatedByGuid",
                table: "MenuCategories",
                column: "CreatedByGuid",
                principalTable: "Users",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuCategories_Users_UpdatedByGuid",
                table: "MenuCategories",
                column: "UpdatedByGuid",
                principalTable: "Users",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_Users_CreatedByGuid",
                table: "MenuItems",
                column: "CreatedByGuid",
                principalTable: "Users",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_Users_UpdatedByGuid",
                table: "MenuItems",
                column: "UpdatedByGuid",
                principalTable: "Users",
                principalColumn: "Guid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuCategories_Users_CreatedByGuid",
                table: "MenuCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuCategories_Users_UpdatedByGuid",
                table: "MenuCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_Users_CreatedByGuid",
                table: "MenuItems");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_Users_UpdatedByGuid",
                table: "MenuItems");

            migrationBuilder.DropIndex(
                name: "IX_MenuItems_CreatedByGuid",
                table: "MenuItems");

            migrationBuilder.DropIndex(
                name: "IX_MenuItems_UpdatedByGuid",
                table: "MenuItems");

            migrationBuilder.DropIndex(
                name: "IX_MenuCategories_CreatedByGuid",
                table: "MenuCategories");

            migrationBuilder.DropIndex(
                name: "IX_MenuCategories_UpdatedByGuid",
                table: "MenuCategories");

            migrationBuilder.DropColumn(
                name: "CreatedByGuid",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "UpdatedByGuid",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "CreatedByGuid",
                table: "MenuCategories");

            migrationBuilder.DropColumn(
                name: "UpdatedByGuid",
                table: "MenuCategories");
        }
    }
}
