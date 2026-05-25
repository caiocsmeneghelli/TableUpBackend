using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TableUp.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddRestaurantReferenceOnMenuCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RestaurantGuid",
                table: "MenuCategories",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_MenuCategories_RestaurantGuid",
                table: "MenuCategories",
                column: "RestaurantGuid");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuCategories_Restaurants_RestaurantGuid",
                table: "MenuCategories",
                column: "RestaurantGuid",
                principalTable: "Restaurants",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuCategories_Restaurants_RestaurantGuid",
                table: "MenuCategories");

            migrationBuilder.DropIndex(
                name: "IX_MenuCategories_RestaurantGuid",
                table: "MenuCategories");

            migrationBuilder.DropColumn(
                name: "RestaurantGuid",
                table: "MenuCategories");
        }
    }
}
