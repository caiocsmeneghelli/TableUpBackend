using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TableUp.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddSnakeCaseOnDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuCategories_Restaurants_RestaurantGuid",
                table: "MenuCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuCategories_Users_CreatedByGuid",
                table: "MenuCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuCategories_Users_UpdatedByGuid",
                table: "MenuCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_MenuCategories_CategoryGuid",
                table: "MenuItems");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_Users_CreatedByGuid",
                table: "MenuItems");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_Users_UpdatedByGuid",
                table: "MenuItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderBills_Tables_TableGuid",
                table: "OrderBills");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderBills_Users_CreatedByGuid",
                table: "OrderBills");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderBills_Users_UpdatedByGuid",
                table: "OrderBills");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_MenuItems_MenuItemGuid",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_OrderBills_OrderBillGuid",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Users_CreatedByGuid",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Users_UpdatedByGuid",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_Users_CreatedByGuid",
                table: "Restaurants");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_Users_UpdatedByGuid",
                table: "Restaurants");

            migrationBuilder.DropForeignKey(
                name: "FK_Tables_Restaurants_RestaurantGuid",
                table: "Tables");

            migrationBuilder.DropForeignKey(
                name: "FK_Tables_Users_CreatedByGuid",
                table: "Tables");

            migrationBuilder.DropForeignKey(
                name: "FK_Tables_Users_UpdatedByGuid",
                table: "Tables");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tables",
                table: "Tables");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Restaurants",
                table: "Restaurants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderBills",
                table: "OrderBills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuItems",
                table: "MenuItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuCategories",
                table: "MenuCategories");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "Tables",
                newName: "tables");

            migrationBuilder.RenameTable(
                name: "Restaurants",
                newName: "restaurants");

            migrationBuilder.RenameTable(
                name: "OrderItems",
                newName: "order_items");

            migrationBuilder.RenameTable(
                name: "OrderBills",
                newName: "order_bills");

            migrationBuilder.RenameTable(
                name: "MenuItems",
                newName: "menu_items");

            migrationBuilder.RenameTable(
                name: "MenuCategories",
                newName: "menu_categories");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "users",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "users",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "users",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Guid",
                table: "users",
                newName: "guid");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "users",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "users",
                newName: "password_hash");

            migrationBuilder.RenameColumn(
                name: "LastLoginAt",
                table: "users",
                newName: "last_login_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "users",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "tables",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "tables",
                newName: "number");

            migrationBuilder.RenameColumn(
                name: "Guid",
                table: "tables",
                newName: "guid");

            migrationBuilder.RenameColumn(
                name: "UpdatedByGuid",
                table: "tables",
                newName: "updated_by_guid");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "tables",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "TableToken",
                table: "tables",
                newName: "table_token");

            migrationBuilder.RenameColumn(
                name: "RestaurantGuid",
                table: "tables",
                newName: "restaurant_guid");

            migrationBuilder.RenameColumn(
                name: "CreatedByGuid",
                table: "tables",
                newName: "created_by_guid");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "tables",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_Tables_UpdatedByGuid",
                table: "tables",
                newName: "ix_tables_updated_by_guid");

            migrationBuilder.RenameIndex(
                name: "IX_Tables_RestaurantGuid",
                table: "tables",
                newName: "ix_tables_restaurant_guid");

            migrationBuilder.RenameIndex(
                name: "IX_Tables_CreatedByGuid",
                table: "tables",
                newName: "ix_tables_created_by_guid");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "restaurants",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Slug",
                table: "restaurants",
                newName: "slug");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "restaurants",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "restaurants",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "restaurants",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Guid",
                table: "restaurants",
                newName: "guid");

            migrationBuilder.RenameColumn(
                name: "UpdatedByGuid",
                table: "restaurants",
                newName: "updated_by_guid");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "restaurants",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "restaurants",
                newName: "image_url");

            migrationBuilder.RenameColumn(
                name: "CreatedByGuid",
                table: "restaurants",
                newName: "created_by_guid");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "restaurants",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_Restaurants_UpdatedByGuid",
                table: "restaurants",
                newName: "ix_restaurants_updated_by_guid");

            migrationBuilder.RenameIndex(
                name: "IX_Restaurants_CreatedByGuid",
                table: "restaurants",
                newName: "ix_restaurants_created_by_guid");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "order_items",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "order_items",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "Guid",
                table: "order_items",
                newName: "guid");

            migrationBuilder.RenameColumn(
                name: "UpdatedByGuid",
                table: "order_items",
                newName: "updated_by_guid");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "order_items",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "StatusOrderItem",
                table: "order_items",
                newName: "status_order_item");

            migrationBuilder.RenameColumn(
                name: "OrderBillGuid",
                table: "order_items",
                newName: "order_bill_guid");

            migrationBuilder.RenameColumn(
                name: "MenuItemGuid",
                table: "order_items",
                newName: "menu_item_guid");

            migrationBuilder.RenameColumn(
                name: "CreatedByGuid",
                table: "order_items",
                newName: "created_by_guid");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "order_items",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_UpdatedByGuid",
                table: "order_items",
                newName: "ix_order_items_updated_by_guid");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_OrderBillGuid",
                table: "order_items",
                newName: "ix_order_items_order_bill_guid");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_MenuItemGuid",
                table: "order_items",
                newName: "ix_order_items_menu_item_guid");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_CreatedByGuid",
                table: "order_items",
                newName: "ix_order_items_created_by_guid");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "order_bills",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "order_bills",
                newName: "amount");

            migrationBuilder.RenameColumn(
                name: "Guid",
                table: "order_bills",
                newName: "guid");

            migrationBuilder.RenameColumn(
                name: "UpdatedByGuid",
                table: "order_bills",
                newName: "updated_by_guid");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "order_bills",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "TableGuid",
                table: "order_bills",
                newName: "table_guid");

            migrationBuilder.RenameColumn(
                name: "StatusOrderBill",
                table: "order_bills",
                newName: "status_order_bill");

            migrationBuilder.RenameColumn(
                name: "CreatedByGuid",
                table: "order_bills",
                newName: "created_by_guid");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "order_bills",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_OrderBills_UpdatedByGuid",
                table: "order_bills",
                newName: "ix_order_bills_updated_by_guid");

            migrationBuilder.RenameIndex(
                name: "IX_OrderBills_TableGuid",
                table: "order_bills",
                newName: "ix_order_bills_table_guid");

            migrationBuilder.RenameIndex(
                name: "IX_OrderBills_CreatedByGuid",
                table: "order_bills",
                newName: "ix_order_bills_created_by_guid");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "menu_items",
                newName: "value");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "menu_items",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "menu_items",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "menu_items",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Guid",
                table: "menu_items",
                newName: "guid");

            migrationBuilder.RenameColumn(
                name: "UpdatedByGuid",
                table: "menu_items",
                newName: "updated_by_guid");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "menu_items",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "CreatedByGuid",
                table: "menu_items",
                newName: "created_by_guid");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "menu_items",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "CategoryGuid",
                table: "menu_items",
                newName: "category_guid");

            migrationBuilder.RenameIndex(
                name: "IX_MenuItems_UpdatedByGuid",
                table: "menu_items",
                newName: "ix_menu_items_updated_by_guid");

            migrationBuilder.RenameIndex(
                name: "IX_MenuItems_CreatedByGuid",
                table: "menu_items",
                newName: "ix_menu_items_created_by_guid");

            migrationBuilder.RenameIndex(
                name: "IX_MenuItems_CategoryGuid",
                table: "menu_items",
                newName: "ix_menu_items_category_guid");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "menu_categories",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "menu_categories",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Guid",
                table: "menu_categories",
                newName: "guid");

            migrationBuilder.RenameColumn(
                name: "UpdatedByGuid",
                table: "menu_categories",
                newName: "updated_by_guid");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "menu_categories",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "RestaurantGuid",
                table: "menu_categories",
                newName: "restaurant_guid");

            migrationBuilder.RenameColumn(
                name: "CreatedByGuid",
                table: "menu_categories",
                newName: "created_by_guid");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "menu_categories",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_MenuCategories_UpdatedByGuid",
                table: "menu_categories",
                newName: "ix_menu_categories_updated_by_guid");

            migrationBuilder.RenameIndex(
                name: "IX_MenuCategories_RestaurantGuid",
                table: "menu_categories",
                newName: "ix_menu_categories_restaurant_guid");

            migrationBuilder.RenameIndex(
                name: "IX_MenuCategories_CreatedByGuid",
                table: "menu_categories",
                newName: "ix_menu_categories_created_by_guid");

            migrationBuilder.AddPrimaryKey(
                name: "pk_users",
                table: "users",
                column: "guid");

            migrationBuilder.AddPrimaryKey(
                name: "pk_tables",
                table: "tables",
                column: "guid");

            migrationBuilder.AddPrimaryKey(
                name: "pk_restaurants",
                table: "restaurants",
                column: "guid");

            migrationBuilder.AddPrimaryKey(
                name: "pk_order_items",
                table: "order_items",
                column: "guid");

            migrationBuilder.AddPrimaryKey(
                name: "pk_order_bills",
                table: "order_bills",
                column: "guid");

            migrationBuilder.AddPrimaryKey(
                name: "pk_menu_items",
                table: "menu_items",
                column: "guid");

            migrationBuilder.AddPrimaryKey(
                name: "pk_menu_categories",
                table: "menu_categories",
                column: "guid");

            migrationBuilder.AddForeignKey(
                name: "fk_menu_categories_restaurants_restaurant_guid",
                table: "menu_categories",
                column: "restaurant_guid",
                principalTable: "restaurants",
                principalColumn: "guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_menu_categories_users_created_by_guid",
                table: "menu_categories",
                column: "created_by_guid",
                principalTable: "users",
                principalColumn: "guid");

            migrationBuilder.AddForeignKey(
                name: "fk_menu_categories_users_updated_by_guid",
                table: "menu_categories",
                column: "updated_by_guid",
                principalTable: "users",
                principalColumn: "guid");

            migrationBuilder.AddForeignKey(
                name: "fk_menu_items_menu_categories_category_guid",
                table: "menu_items",
                column: "category_guid",
                principalTable: "menu_categories",
                principalColumn: "guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_menu_items_users_created_by_guid",
                table: "menu_items",
                column: "created_by_guid",
                principalTable: "users",
                principalColumn: "guid");

            migrationBuilder.AddForeignKey(
                name: "fk_menu_items_users_updated_by_guid",
                table: "menu_items",
                column: "updated_by_guid",
                principalTable: "users",
                principalColumn: "guid");

            migrationBuilder.AddForeignKey(
                name: "fk_order_bills_tables_table_guid",
                table: "order_bills",
                column: "table_guid",
                principalTable: "tables",
                principalColumn: "guid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_order_bills_users_created_by_guid",
                table: "order_bills",
                column: "created_by_guid",
                principalTable: "users",
                principalColumn: "guid");

            migrationBuilder.AddForeignKey(
                name: "fk_order_bills_users_updated_by_guid",
                table: "order_bills",
                column: "updated_by_guid",
                principalTable: "users",
                principalColumn: "guid");

            migrationBuilder.AddForeignKey(
                name: "fk_order_items_menu_items_menu_item_guid",
                table: "order_items",
                column: "menu_item_guid",
                principalTable: "menu_items",
                principalColumn: "guid");

            migrationBuilder.AddForeignKey(
                name: "fk_order_items_order_bills_order_bill_guid",
                table: "order_items",
                column: "order_bill_guid",
                principalTable: "order_bills",
                principalColumn: "guid");

            migrationBuilder.AddForeignKey(
                name: "fk_order_items_users_created_by_guid",
                table: "order_items",
                column: "created_by_guid",
                principalTable: "users",
                principalColumn: "guid");

            migrationBuilder.AddForeignKey(
                name: "fk_order_items_users_updated_by_guid",
                table: "order_items",
                column: "updated_by_guid",
                principalTable: "users",
                principalColumn: "guid");

            migrationBuilder.AddForeignKey(
                name: "fk_restaurants_users_created_by_guid",
                table: "restaurants",
                column: "created_by_guid",
                principalTable: "users",
                principalColumn: "guid");

            migrationBuilder.AddForeignKey(
                name: "fk_restaurants_users_updated_by_guid",
                table: "restaurants",
                column: "updated_by_guid",
                principalTable: "users",
                principalColumn: "guid");

            migrationBuilder.AddForeignKey(
                name: "fk_tables_restaurants_restaurant_guid",
                table: "tables",
                column: "restaurant_guid",
                principalTable: "restaurants",
                principalColumn: "guid");

            migrationBuilder.AddForeignKey(
                name: "fk_tables_users_created_by_guid",
                table: "tables",
                column: "created_by_guid",
                principalTable: "users",
                principalColumn: "guid");

            migrationBuilder.AddForeignKey(
                name: "fk_tables_users_updated_by_guid",
                table: "tables",
                column: "updated_by_guid",
                principalTable: "users",
                principalColumn: "guid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_menu_categories_restaurants_restaurant_guid",
                table: "menu_categories");

            migrationBuilder.DropForeignKey(
                name: "fk_menu_categories_users_created_by_guid",
                table: "menu_categories");

            migrationBuilder.DropForeignKey(
                name: "fk_menu_categories_users_updated_by_guid",
                table: "menu_categories");

            migrationBuilder.DropForeignKey(
                name: "fk_menu_items_menu_categories_category_guid",
                table: "menu_items");

            migrationBuilder.DropForeignKey(
                name: "fk_menu_items_users_created_by_guid",
                table: "menu_items");

            migrationBuilder.DropForeignKey(
                name: "fk_menu_items_users_updated_by_guid",
                table: "menu_items");

            migrationBuilder.DropForeignKey(
                name: "fk_order_bills_tables_table_guid",
                table: "order_bills");

            migrationBuilder.DropForeignKey(
                name: "fk_order_bills_users_created_by_guid",
                table: "order_bills");

            migrationBuilder.DropForeignKey(
                name: "fk_order_bills_users_updated_by_guid",
                table: "order_bills");

            migrationBuilder.DropForeignKey(
                name: "fk_order_items_menu_items_menu_item_guid",
                table: "order_items");

            migrationBuilder.DropForeignKey(
                name: "fk_order_items_order_bills_order_bill_guid",
                table: "order_items");

            migrationBuilder.DropForeignKey(
                name: "fk_order_items_users_created_by_guid",
                table: "order_items");

            migrationBuilder.DropForeignKey(
                name: "fk_order_items_users_updated_by_guid",
                table: "order_items");

            migrationBuilder.DropForeignKey(
                name: "fk_restaurants_users_created_by_guid",
                table: "restaurants");

            migrationBuilder.DropForeignKey(
                name: "fk_restaurants_users_updated_by_guid",
                table: "restaurants");

            migrationBuilder.DropForeignKey(
                name: "fk_tables_restaurants_restaurant_guid",
                table: "tables");

            migrationBuilder.DropForeignKey(
                name: "fk_tables_users_created_by_guid",
                table: "tables");

            migrationBuilder.DropForeignKey(
                name: "fk_tables_users_updated_by_guid",
                table: "tables");

            migrationBuilder.DropPrimaryKey(
                name: "pk_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "pk_tables",
                table: "tables");

            migrationBuilder.DropPrimaryKey(
                name: "pk_restaurants",
                table: "restaurants");

            migrationBuilder.DropPrimaryKey(
                name: "pk_order_items",
                table: "order_items");

            migrationBuilder.DropPrimaryKey(
                name: "pk_order_bills",
                table: "order_bills");

            migrationBuilder.DropPrimaryKey(
                name: "pk_menu_items",
                table: "menu_items");

            migrationBuilder.DropPrimaryKey(
                name: "pk_menu_categories",
                table: "menu_categories");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "tables",
                newName: "Tables");

            migrationBuilder.RenameTable(
                name: "restaurants",
                newName: "Restaurants");

            migrationBuilder.RenameTable(
                name: "order_items",
                newName: "OrderItems");

            migrationBuilder.RenameTable(
                name: "order_bills",
                newName: "OrderBills");

            migrationBuilder.RenameTable(
                name: "menu_items",
                newName: "MenuItems");

            migrationBuilder.RenameTable(
                name: "menu_categories",
                newName: "MenuCategories");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "Users",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Users",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Users",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "guid",
                table: "Users",
                newName: "Guid");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "Users",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "password_hash",
                table: "Users",
                newName: "PasswordHash");

            migrationBuilder.RenameColumn(
                name: "last_login_at",
                table: "Users",
                newName: "LastLoginAt");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Users",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Tables",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "number",
                table: "Tables",
                newName: "Number");

            migrationBuilder.RenameColumn(
                name: "guid",
                table: "Tables",
                newName: "Guid");

            migrationBuilder.RenameColumn(
                name: "updated_by_guid",
                table: "Tables",
                newName: "UpdatedByGuid");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "Tables",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "table_token",
                table: "Tables",
                newName: "TableToken");

            migrationBuilder.RenameColumn(
                name: "restaurant_guid",
                table: "Tables",
                newName: "RestaurantGuid");

            migrationBuilder.RenameColumn(
                name: "created_by_guid",
                table: "Tables",
                newName: "CreatedByGuid");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Tables",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "ix_tables_updated_by_guid",
                table: "Tables",
                newName: "IX_Tables_UpdatedByGuid");

            migrationBuilder.RenameIndex(
                name: "ix_tables_restaurant_guid",
                table: "Tables",
                newName: "IX_Tables_RestaurantGuid");

            migrationBuilder.RenameIndex(
                name: "ix_tables_created_by_guid",
                table: "Tables",
                newName: "IX_Tables_CreatedByGuid");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Restaurants",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "slug",
                table: "Restaurants",
                newName: "Slug");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Restaurants",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Restaurants",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Restaurants",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "guid",
                table: "Restaurants",
                newName: "Guid");

            migrationBuilder.RenameColumn(
                name: "updated_by_guid",
                table: "Restaurants",
                newName: "UpdatedByGuid");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "Restaurants",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "image_url",
                table: "Restaurants",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "created_by_guid",
                table: "Restaurants",
                newName: "CreatedByGuid");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Restaurants",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "ix_restaurants_updated_by_guid",
                table: "Restaurants",
                newName: "IX_Restaurants_UpdatedByGuid");

            migrationBuilder.RenameIndex(
                name: "ix_restaurants_created_by_guid",
                table: "Restaurants",
                newName: "IX_Restaurants_CreatedByGuid");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "OrderItems",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "OrderItems",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "guid",
                table: "OrderItems",
                newName: "Guid");

            migrationBuilder.RenameColumn(
                name: "updated_by_guid",
                table: "OrderItems",
                newName: "UpdatedByGuid");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "OrderItems",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "status_order_item",
                table: "OrderItems",
                newName: "StatusOrderItem");

            migrationBuilder.RenameColumn(
                name: "order_bill_guid",
                table: "OrderItems",
                newName: "OrderBillGuid");

            migrationBuilder.RenameColumn(
                name: "menu_item_guid",
                table: "OrderItems",
                newName: "MenuItemGuid");

            migrationBuilder.RenameColumn(
                name: "created_by_guid",
                table: "OrderItems",
                newName: "CreatedByGuid");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "OrderItems",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "ix_order_items_updated_by_guid",
                table: "OrderItems",
                newName: "IX_OrderItems_UpdatedByGuid");

            migrationBuilder.RenameIndex(
                name: "ix_order_items_order_bill_guid",
                table: "OrderItems",
                newName: "IX_OrderItems_OrderBillGuid");

            migrationBuilder.RenameIndex(
                name: "ix_order_items_menu_item_guid",
                table: "OrderItems",
                newName: "IX_OrderItems_MenuItemGuid");

            migrationBuilder.RenameIndex(
                name: "ix_order_items_created_by_guid",
                table: "OrderItems",
                newName: "IX_OrderItems_CreatedByGuid");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "OrderBills",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "amount",
                table: "OrderBills",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "guid",
                table: "OrderBills",
                newName: "Guid");

            migrationBuilder.RenameColumn(
                name: "updated_by_guid",
                table: "OrderBills",
                newName: "UpdatedByGuid");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "OrderBills",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "table_guid",
                table: "OrderBills",
                newName: "TableGuid");

            migrationBuilder.RenameColumn(
                name: "status_order_bill",
                table: "OrderBills",
                newName: "StatusOrderBill");

            migrationBuilder.RenameColumn(
                name: "created_by_guid",
                table: "OrderBills",
                newName: "CreatedByGuid");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "OrderBills",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "ix_order_bills_updated_by_guid",
                table: "OrderBills",
                newName: "IX_OrderBills_UpdatedByGuid");

            migrationBuilder.RenameIndex(
                name: "ix_order_bills_table_guid",
                table: "OrderBills",
                newName: "IX_OrderBills_TableGuid");

            migrationBuilder.RenameIndex(
                name: "ix_order_bills_created_by_guid",
                table: "OrderBills",
                newName: "IX_OrderBills_CreatedByGuid");

            migrationBuilder.RenameColumn(
                name: "value",
                table: "MenuItems",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "MenuItems",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "MenuItems",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "MenuItems",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "guid",
                table: "MenuItems",
                newName: "Guid");

            migrationBuilder.RenameColumn(
                name: "updated_by_guid",
                table: "MenuItems",
                newName: "UpdatedByGuid");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "MenuItems",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "created_by_guid",
                table: "MenuItems",
                newName: "CreatedByGuid");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "MenuItems",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "category_guid",
                table: "MenuItems",
                newName: "CategoryGuid");

            migrationBuilder.RenameIndex(
                name: "ix_menu_items_updated_by_guid",
                table: "MenuItems",
                newName: "IX_MenuItems_UpdatedByGuid");

            migrationBuilder.RenameIndex(
                name: "ix_menu_items_created_by_guid",
                table: "MenuItems",
                newName: "IX_MenuItems_CreatedByGuid");

            migrationBuilder.RenameIndex(
                name: "ix_menu_items_category_guid",
                table: "MenuItems",
                newName: "IX_MenuItems_CategoryGuid");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "MenuCategories",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "MenuCategories",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "guid",
                table: "MenuCategories",
                newName: "Guid");

            migrationBuilder.RenameColumn(
                name: "updated_by_guid",
                table: "MenuCategories",
                newName: "UpdatedByGuid");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "MenuCategories",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "restaurant_guid",
                table: "MenuCategories",
                newName: "RestaurantGuid");

            migrationBuilder.RenameColumn(
                name: "created_by_guid",
                table: "MenuCategories",
                newName: "CreatedByGuid");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "MenuCategories",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "ix_menu_categories_updated_by_guid",
                table: "MenuCategories",
                newName: "IX_MenuCategories_UpdatedByGuid");

            migrationBuilder.RenameIndex(
                name: "ix_menu_categories_restaurant_guid",
                table: "MenuCategories",
                newName: "IX_MenuCategories_RestaurantGuid");

            migrationBuilder.RenameIndex(
                name: "ix_menu_categories_created_by_guid",
                table: "MenuCategories",
                newName: "IX_MenuCategories_CreatedByGuid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tables",
                table: "Tables",
                column: "Guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Restaurants",
                table: "Restaurants",
                column: "Guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems",
                column: "Guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderBills",
                table: "OrderBills",
                column: "Guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuItems",
                table: "MenuItems",
                column: "Guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuCategories",
                table: "MenuCategories",
                column: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuCategories_Restaurants_RestaurantGuid",
                table: "MenuCategories",
                column: "RestaurantGuid",
                principalTable: "Restaurants",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_MenuItems_MenuCategories_CategoryGuid",
                table: "MenuItems",
                column: "CategoryGuid",
                principalTable: "MenuCategories",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_OrderBills_Tables_TableGuid",
                table: "OrderBills",
                column: "TableGuid",
                principalTable: "Tables",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderBills_Users_CreatedByGuid",
                table: "OrderBills",
                column: "CreatedByGuid",
                principalTable: "Users",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderBills_Users_UpdatedByGuid",
                table: "OrderBills",
                column: "UpdatedByGuid",
                principalTable: "Users",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_MenuItems_MenuItemGuid",
                table: "OrderItems",
                column: "MenuItemGuid",
                principalTable: "MenuItems",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_OrderBills_OrderBillGuid",
                table: "OrderItems",
                column: "OrderBillGuid",
                principalTable: "OrderBills",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Users_CreatedByGuid",
                table: "OrderItems",
                column: "CreatedByGuid",
                principalTable: "Users",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Users_UpdatedByGuid",
                table: "OrderItems",
                column: "UpdatedByGuid",
                principalTable: "Users",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_Users_CreatedByGuid",
                table: "Restaurants",
                column: "CreatedByGuid",
                principalTable: "Users",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_Users_UpdatedByGuid",
                table: "Restaurants",
                column: "UpdatedByGuid",
                principalTable: "Users",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_Restaurants_RestaurantGuid",
                table: "Tables",
                column: "RestaurantGuid",
                principalTable: "Restaurants",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_Users_CreatedByGuid",
                table: "Tables",
                column: "CreatedByGuid",
                principalTable: "Users",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_Users_UpdatedByGuid",
                table: "Tables",
                column: "UpdatedByGuid",
                principalTable: "Users",
                principalColumn: "Guid");
        }
    }
}
