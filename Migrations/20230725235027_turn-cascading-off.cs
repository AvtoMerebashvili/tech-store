using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tech_store.Migrations
{
    /// <inheritdoc />
    public partial class turncascadingoff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_addresses_delivery_address_id",
                table: "orders");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_addresses_delivery_address_id",
                table: "orders",
                column: "delivery_address_id",
                principalTable: "addresses",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_addresses_delivery_address_id",
                table: "orders");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_addresses_delivery_address_id",
                table: "orders",
                column: "delivery_address_id",
                principalTable: "addresses",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
