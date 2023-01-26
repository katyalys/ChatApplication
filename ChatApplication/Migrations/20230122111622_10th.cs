using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatApplication.Migrations
{
    /// <inheritdoc />
    public partial class _10th : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_ChatDb.UsersModel_RecieverUserId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_ChatDb.UsersModel_UsersModelUserId",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Messages",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatDb.UsersModel",
                table: "ChatDb.UsersModel");

            migrationBuilder.RenameTable(
                name: "Messages",
                newName: "MessageModel");

            migrationBuilder.RenameTable(
                name: "ChatDb.UsersModel",
                newName: "UsersModel");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_MessageModel",
                table: "MessageModel");

            migrationBuilder.RenameTable(
                name: "UsersModel",
                newName: "ChatDb.UsersModel");

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
                name: "PK_ChatDb.UsersModel",
                table: "ChatDb.UsersModel",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Messages",
                table: "Messages",
                column: "MessageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_ChatDb.UsersModel_RecieverUserId",
                table: "Messages",
                column: "RecieverUserId",
                principalTable: "ChatDb.UsersModel",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_ChatDb.UsersModel_UsersModelUserId",
                table: "Messages",
                column: "UsersModelUserId",
                principalTable: "ChatDb.UsersModel",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
