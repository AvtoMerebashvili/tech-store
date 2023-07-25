using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tech_store.Migrations
{
    /// <inheritdoc />
    public partial class tmpcommentroles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_roles_role_id",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_role_id",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_roles",
                table: "roles");

            migrationBuilder.RenameTable(
                name: "roles",
                newName: "Role");

            migrationBuilder.AddColumn<int>(
                name: "Roleid",
                table: "users",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Role",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                table: "Role",
                column: "id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_Role_Roleid",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_Roleid",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "Roleid",
                table: "users");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "roles");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "roles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_roles",
                table: "roles",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_users_role_id",
                table: "users",
                column: "role_id");

            migrationBuilder.AddForeignKey(
                name: "FK_users_roles_role_id",
                table: "users",
                column: "role_id",
                principalTable: "roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
