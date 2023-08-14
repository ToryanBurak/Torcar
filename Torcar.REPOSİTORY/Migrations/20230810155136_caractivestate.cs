using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Torcar.REPOSITORY.Migrations
{
    /// <inheritdoc />
    public partial class caractivestate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActiveState",
                table: "Cars");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "ActiveState",
                table: "Cars",
                type: "tinyint unsigned",
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}
