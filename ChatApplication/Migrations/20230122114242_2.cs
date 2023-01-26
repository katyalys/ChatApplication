using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatApplication.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MessageModel_UsersModel_RecieverUserId",
                table: "MessageModel");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageModel_UsersModel_UsersModelUserId",
                table: "MessageModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersModel",
                table: "UsersModel");

            migrationBuilder.RenameTable(
                name: "UsersModel",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MessageModel_Users_RecieverUserId",
                table: "MessageModel",
                column: "RecieverUserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MessageModel_Users_UsersModelUserId",
                table: "MessageModel",
                column: "UsersModelUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MessageModel_Users_RecieverUserId",
                table: "MessageModel");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageModel_Users_UsersModelUserId",
                table: "MessageModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "UsersModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersModel",
                table: "UsersModel",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MessageModel_UsersModel_RecieverUserId",
                table: "MessageModel",
                column: "RecieverUserId",
                principalTable: "UsersModel",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MessageModel_UsersModel_UsersModelUserId",
                table: "MessageModel",
                column: "UsersModelUserId",
                principalTable: "UsersModel",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
