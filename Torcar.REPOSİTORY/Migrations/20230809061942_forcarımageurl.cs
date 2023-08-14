using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Torcar.REPOSITORY.Migrations
{
    /// <inheritdoc />
    public partial class forcarımageurl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Cars",
                type: "longtext",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Cars");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Cars",
                type: "longblob",
                nullable: false);
        }
    }
}
