using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class NamaMigrasiii : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Robots");

            migrationBuilder.AddColumn<int>(
                name: "SerialNumber",
                table: "Robots",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SerialNumber",
                table: "Robots");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Robots",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
