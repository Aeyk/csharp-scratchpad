using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Todo.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "lists",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    TodoListId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_lists_lists_TodoListId",
                        column: x => x.TodoListId,
                        principalTable: "lists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "items",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Content = table.Column<string>(type: "TEXT", nullable: false),
                    TodoListId = table.Column<string>(type: "TEXT", nullable: true),
                    State = table.Column<ushort>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_items_lists_TodoListId",
                        column: x => x.TodoListId,
                        principalTable: "lists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_items_TodoListId",
                table: "items",
                column: "TodoListId");

            migrationBuilder.CreateIndex(
                name: "IX_lists_TodoListId",
                table: "lists",
                column: "TodoListId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "items");

            migrationBuilder.DropTable(
                name: "lists");
        }
    }
}
