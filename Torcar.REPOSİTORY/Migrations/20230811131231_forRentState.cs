using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Torcar.REPOSITORY.Migrations
{
    /// <inheritdoc />
    public partial class forRentState : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RentState",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RentState",
                table: "Cars");
        }
    }
}
