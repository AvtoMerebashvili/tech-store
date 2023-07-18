using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tech_store.Migrations
{
    /// <inheritdoc />
    public partial class updatedatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name_geo",
                table: "countries");

            migrationBuilder.DropColumn(
                name: "name_geo",
                table: "cities");

            migrationBuilder.RenameColumn(
                name: "name_lat",
                table: "countries",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "name_lat",
                table: "cities",
                newName: "name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "countries",
                newName: "name_lat");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "cities",
                newName: "name_lat");

            migrationBuilder.AddColumn<string>(
                name: "name_geo",
                table: "countries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "name_geo",
                table: "cities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
