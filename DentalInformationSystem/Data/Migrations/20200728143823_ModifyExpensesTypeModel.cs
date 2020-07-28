using Microsoft.EntityFrameworkCore.Migrations;

namespace DentalInformationSystem.Data.Migrations
{
    public partial class ModifyExpensesTypeModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpensesName",
                table: "ExpensesTypes");

            migrationBuilder.AddColumn<string>(
                name: "ExpensesTypeName",
                table: "ExpensesTypes",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpensesTypeName",
                table: "ExpensesTypes");

            migrationBuilder.AddColumn<string>(
                name: "ExpensesName",
                table: "ExpensesTypes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
