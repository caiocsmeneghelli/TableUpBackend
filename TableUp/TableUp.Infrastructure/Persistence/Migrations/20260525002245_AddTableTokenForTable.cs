using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TableUp.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddTableTokenForTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TableToken",
                table: "Tables",
                type: "character varying(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TableToken",
                table: "Tables");
        }
    }
}
