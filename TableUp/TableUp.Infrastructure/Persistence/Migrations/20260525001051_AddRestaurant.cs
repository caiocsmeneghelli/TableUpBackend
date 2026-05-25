using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TableUp.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddRestaurant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RestaurantGuid",
                table: "Tables",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Slug = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedByGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedByGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Restaurants_Users_CreatedByGuid",
                        column: x => x.CreatedByGuid,
                        principalTable: "Users",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_Restaurants_Users_UpdatedByGuid",
                        column: x => x.UpdatedByGuid,
                        principalTable: "Users",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tables_RestaurantGuid",
                table: "Tables",
                column: "RestaurantGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_CreatedByGuid",
                table: "Restaurants",
                column: "CreatedByGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_UpdatedByGuid",
                table: "Restaurants",
                column: "UpdatedByGuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_Restaurants_RestaurantGuid",
                table: "Tables",
                column: "RestaurantGuid",
                principalTable: "Restaurants",
                principalColumn: "Guid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tables_Restaurants_RestaurantGuid",
                table: "Tables");

            migrationBuilder.DropTable(
                name: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_Tables_RestaurantGuid",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "RestaurantGuid",
                table: "Tables");
        }
    }
}
