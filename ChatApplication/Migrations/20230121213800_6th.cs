using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatApplication.Migrations
{
    /// <inheritdoc />
    public partial class _6th : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MessageModel_EmployeeModel_EmployeeModelEmployeeId",
                table: "MessageModel");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageModel_EmployeeModel_RecieverEmployeeId",
                table: "MessageModel");

            migrationBuilder.DropTable(
                name: "EmployeeModel");

            migrationBuilder.RenameColumn(
                name: "RecieverEmployeeId",
                table: "MessageModel",
                newName: "RecieverUserId");

            migrationBuilder.RenameColumn(
                name: "EmployeeModelEmployeeId",
                table: "MessageModel",
                newName: "UsersModelUserId");

            migrationBuilder.RenameIndex(
                name: "IX_MessageModel_RecieverEmployeeId",
                table: "MessageModel",
                newName: "IX_MessageModel_RecieverUserId");

            migrationBuilder.RenameIndex(
                name: "IX_MessageModel_EmployeeModelEmployeeId",
                table: "MessageModel",
                newName: "IX_MessageModel_UsersModelUserId");

            migrationBuilder.CreateTable(
                name: "UsersModel",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersModel", x => x.UserId);
                });

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

            migrationBuilder.DropTable(
                name: "UsersModel");

            migrationBuilder.RenameColumn(
                name: "UsersModelUserId",
                table: "MessageModel",
                newName: "EmployeeModelEmployeeId");

            migrationBuilder.RenameColumn(
                name: "RecieverUserId",
                table: "MessageModel",
                newName: "RecieverEmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_MessageModel_UsersModelUserId",
                table: "MessageModel",
                newName: "IX_MessageModel_EmployeeModelEmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_MessageModel_RecieverUserId",
                table: "MessageModel",
                newName: "IX_MessageModel_RecieverEmployeeId");

            migrationBuilder.CreateTable(
                name: "EmployeeModel",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeModel", x => x.EmployeeId);
                });

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
    }
}
