using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTS.Host.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabseV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Role_IdRole",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_IdRole",
                table: "User");

            migrationBuilder.DropColumn(
                name: "IdRole",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "IdRoleEntity",
                table: "User",
                newName: "RoleEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleEntityId",
                table: "User",
                column: "RoleEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Role_RoleEntityId",
                table: "User",
                column: "RoleEntityId",
                principalTable: "Role",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Role_RoleEntityId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_RoleEntityId",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "RoleEntityId",
                table: "User",
                newName: "IdRoleEntity");

            migrationBuilder.AddColumn<int>(
                name: "IdRole",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_IdRole",
                table: "User",
                column: "IdRole");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Role_IdRole",
                table: "User",
                column: "IdRole",
                principalTable: "Role",
                principalColumn: "Id");
        }
    }
}
