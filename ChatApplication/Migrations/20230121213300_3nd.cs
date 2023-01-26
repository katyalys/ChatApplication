using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatApplication.Migrations
{
    /// <inheritdoc />
    public partial class _3nd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_RecieverUserId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_UserModelUserId",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "EmployeeId");

            migrationBuilder.RenameColumn(
                name: "UserModelUserId",
                table: "Messages",
                newName: "EmployeeModelEmployeeId");

            migrationBuilder.RenameColumn(
                name: "RecieverUserId",
                table: "Messages",
                newName: "RecieverEmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_UserModelUserId",
                table: "Messages",
                newName: "IX_Messages_EmployeeModelEmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_RecieverUserId",
                table: "Messages",
                newName: "IX_Messages_RecieverEmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_EmployeeModelEmployeeId",
                table: "Messages",
                column: "EmployeeModelEmployeeId",
                principalTable: "Users",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_RecieverEmployeeId",
                table: "Messages",
                column: "RecieverEmployeeId",
                principalTable: "Users",
                principalColumn: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_EmployeeModelEmployeeId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_RecieverEmployeeId",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "RecieverEmployeeId",
                table: "Messages",
                newName: "RecieverUserId");

            migrationBuilder.RenameColumn(
                name: "EmployeeModelEmployeeId",
                table: "Messages",
                newName: "UserModelUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_RecieverEmployeeId",
                table: "Messages",
                newName: "IX_Messages_RecieverUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_EmployeeModelEmployeeId",
                table: "Messages",
                newName: "IX_Messages_UserModelUserId");

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
    }
}
