using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Torcar.REPOSITORY.Migrations
{
    /// <inheritdoc />
    public partial class forObjectState : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "ObjectState",
                table: "Users",
                type: "tinyint unsigned",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "ObjectState",
                table: "Rents",
                type: "tinyint unsigned",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "ObjectState",
                table: "RentRequests",
                type: "tinyint unsigned",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "ObjectState",
                table: "CarSerials",
                type: "tinyint unsigned",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "ObjectState",
                table: "Cars",
                type: "tinyint unsigned",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "ObjectState",
                table: "CarModels",
                type: "tinyint unsigned",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "ObjectState",
                table: "CarMarks",
                type: "tinyint unsigned",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "ObjectState",
                table: "Adverts",
                type: "tinyint unsigned",
                nullable: false,
                defaultValue: (byte)0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ObjectState",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ObjectState",
                table: "Rents");

            migrationBuilder.DropColumn(
                name: "ObjectState",
                table: "RentRequests");

            migrationBuilder.DropColumn(
                name: "ObjectState",
                table: "CarSerials");

            migrationBuilder.DropColumn(
                name: "ObjectState",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "ObjectState",
                table: "CarModels");

            migrationBuilder.DropColumn(
                name: "ObjectState",
                table: "CarMarks");

            migrationBuilder.DropColumn(
                name: "ObjectState",
                table: "Adverts");
        }
    }
}
