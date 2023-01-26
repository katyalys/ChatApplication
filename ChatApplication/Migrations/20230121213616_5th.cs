using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatApplication.Migrations
{
    /// <inheritdoc />
    public partial class _5th : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_EmployeeModelEmployeeId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_RecieverEmployeeId",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Messages",
                table: "Messages");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "EmployeeModel");

            migrationBuilder.RenameTable(
                name: "Messages",
                newName: "MessageModel");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_RecieverEmployeeId",
                table: "MessageModel",
                newName: "IX_MessageModel_RecieverEmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_EmployeeModelEmployeeId",
                table: "MessageModel",
                newName: "IX_MessageModel_EmployeeModelEmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeModel",
                table: "EmployeeModel",
                column: "EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MessageModel",
                table: "MessageModel",
                column: "MessageId");

            migrationBuilder.AddForeignKey(
                name: "FK_MessageModel_EmployeeModel_EmployeeModelEmployeeId",
                table: "MessageModel",
                column: "EmployeeModelEmployeeId",
                principalTable: "EmployeeModel",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MessageModel_EmployeeModel_RecieverEmployeeId",
                table: "MessageModel",
                column: "RecieverEmployeeId",
                principalTable: "EmployeeModel",
                principalColumn: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MessageModel_EmployeeModel_EmployeeModelEmployeeId",
                table: "MessageModel");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageModel_EmployeeModel_RecieverEmployeeId",
                table: "MessageModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MessageModel",
                table: "MessageModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeModel",
                table: "EmployeeModel");

            migrationBuilder.RenameTable(
                name: "MessageModel",
                newName: "Messages");

            migrationBuilder.RenameTable(
                name: "EmployeeModel",
                newName: "Users");

            migrationBuilder.RenameIndex(
                name: "IX_MessageModel_RecieverEmployeeId",
                table: "Messages",
                newName: "IX_Messages_RecieverEmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_MessageModel_EmployeeModelEmployeeId",
                table: "Messages",
                newName: "IX_Messages_EmployeeModelEmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Messages",
                table: "Messages",
                column: "MessageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "EmployeeId");

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
    }
}
