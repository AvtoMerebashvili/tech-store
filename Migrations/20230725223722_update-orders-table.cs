using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tech_store.Migrations
{
    /// <inheritdoc />
    public partial class updateorderstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "owner_id",
                table: "orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_orders_owner_id",
                table: "orders",
                column: "owner_id");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_users_owner_id",
                table: "orders",
                column: "owner_id",
                principalTable: "users",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_users_owner_id",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_owner_id",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "owner_id",
                table: "orders");
        }
    }
}
