using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tech_store.Migrations
{
    /// <inheritdoc />
    public partial class tmpcommentrolesagain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_Role_Roleid",
                table: "users");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropIndex(
                name: "IX_users_Roleid",
                table: "users");

            migrationBuilder.DropColumn(
                name: "Roleid",
                table: "users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Roleid",
                table: "users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_Roleid",
                table: "users",
                column: "Roleid");

            migrationBuilder.AddForeignKey(
                name: "FK_users_Role_Roleid",
                table: "users",
                column: "Roleid",
                principalTable: "Role",
                principalColumn: "id");
        }
    }
}
