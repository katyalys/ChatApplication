using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatApplication.Migrations
{
    /// <inheritdoc />
    public partial class _2nd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_UserMesId1",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "UserMesId1",
                table: "Messages",
                newName: "UserModelUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_UserMesId1",
                table: "Messages",
                newName: "IX_Messages_UserModelUserId");

            migrationBuilder.AddColumn<int>(
                name: "RecieverUserId",
                table: "Messages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_RecieverUserId",
                table: "Messages",
                column: "RecieverUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_RecieverUserId",
                table: "Messages",
                column: "RecieverUserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_UserModelUserId",
                table: "Messages",
                column: "UserModelUserId",
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
                name: "FK_Messages_Users_UserModelUserId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_RecieverUserId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "RecieverUserId",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "UserModelUserId",
                table: "Messages",
                newName: "UserMesId1");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_UserModelUserId",
                table: "Messages",
                newName: "IX_Messages_UserMesId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_UserMesId1",
                table: "Messages",
                column: "UserMesId1",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
