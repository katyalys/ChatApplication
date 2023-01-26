using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatApplication.Migrations
{
    /// <inheritdoc />
    public partial class _4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MessageModel_Users_RecieverUserId",
                table: "MessageModel");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageModel_Users_UsersModelUserId",
                table: "MessageModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MessageModel",
                table: "MessageModel");

            migrationBuilder.RenameTable(
                name: "MessageModel",
                newName: "Messages");

            migrationBuilder.RenameIndex(
                name: "IX_MessageModel_UsersModelUserId",
                table: "Messages",
                newName: "IX_Messages_UsersModelUserId");

            migrationBuilder.RenameIndex(
                name: "IX_MessageModel_RecieverUserId",
                table: "Messages",
                newName: "IX_Messages_RecieverUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Messages",
                table: "Messages",
                column: "MessageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_RecieverUserId",
                table: "Messages",
                column: "RecieverUserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_UsersModelUserId",
                table: "Messages",
                column: "UsersModelUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_RecieverUserId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_UsersModelUserId",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Messages",
                table: "Messages");

            migrationBuilder.RenameTable(
                name: "Messages",
                newName: "MessageModel");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_UsersModelUserId",
                table: "MessageModel",
                newName: "IX_MessageModel_UsersModelUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_RecieverUserId",
                table: "MessageModel",
                newName: "IX_MessageModel_RecieverUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MessageModel",
                table: "MessageModel",
                column: "MessageId");

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
    }
}
