using Microsoft.EntityFrameworkCore.Migrations;

namespace DentalInformationSystem.Data.Migrations
{
    public partial class AddDiagnoses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<int>(
                name: "DiagnosisID",
                table: "Protocols",
                nullable: false);

            migrationBuilder.CreateTable(
                name: "Diagnoses",
                columns: table => new
                {
                    DiagnosisID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiagnosisNameSrb = table.Column<string>(nullable: false),
                    DiagnosisNameLatin = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnoses", x => x.DiagnosisID);
                });


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Protocols_Diagnoses_DiagnosisID",
                table: "Protocols");

            migrationBuilder.DropTable(
                name: "Diagnoses");

            migrationBuilder.DropIndex(
                name: "IX_Protocols_DiagnosisID",
                table: "Protocols");

            migrationBuilder.DropColumn(
                name: "DiagnosisID",
                table: "Protocols");

            migrationBuilder.AddColumn<string>(
                name: "Diagnosis",
                table: "Protocols",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }
    }
}
