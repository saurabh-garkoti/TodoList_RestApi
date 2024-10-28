using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CurdTodoList.Migrations
{
    /// <inheritdoc />
    public partial class AddDueDateColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "DueDate",
                table: "Lists",
                type: "date",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "Lists");
        }
    }
}
