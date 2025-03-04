using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API2.Migrations
{
    /// <inheritdoc />
    public partial class AddUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_UserDto_CreatorId",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserDto",
                table: "UserDto");

            migrationBuilder.RenameTable(
                name: "UserDto",
                newName: "User");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_User_CreatorId",
                table: "Tasks",
                column: "CreatorId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_User_CreatorId",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "UserDto");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserDto",
                table: "UserDto",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_UserDto_CreatorId",
                table: "Tasks",
                column: "CreatorId",
                principalTable: "UserDto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
