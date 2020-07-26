using Microsoft.EntityFrameworkCore.Migrations;

namespace DentalInformationSystem.Data.Migrations
{
    public partial class ProtocolModelModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Protocols");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Protocols");

            migrationBuilder.DropColumn(
                name: "NameOfOneParent",
                table: "Protocols");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Protocols");

            migrationBuilder.DropColumn(
                name: "YearOfBirth",
                table: "Protocols");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Protocols",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Protocols",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Protocols",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Protocols",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NameOfOneParent",
                table: "Protocols",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Protocols",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "YearOfBirth",
                table: "Protocols",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
