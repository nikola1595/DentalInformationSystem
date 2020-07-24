using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DentalInformationSystem.Data.Migrations
{
    public partial class InitialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 25, nullable: false),
                    Surname = table.Column<string>(maxLength: 25, nullable: false),
                    NameOfOneParent = table.Column<string>(maxLength: 25, nullable: false),
                    Address = table.Column<string>(maxLength: 50, nullable: false),
                    City = table.Column<string>(maxLength: 25, nullable: false),
                    Telephone = table.Column<string>(maxLength: 30, nullable: false),
                    YearOfBirth = table.Column<int>(maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientID);
                });

            migrationBuilder.CreateTable(
                name: "Protocols",
                columns: table => new
                {
                    ProtocolID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 25, nullable: false),
                    Surname = table.Column<string>(maxLength: 25, nullable: false),
                    NameOfOneParent = table.Column<string>(maxLength: 25, nullable: false),
                    YearOfBirth = table.Column<int>(maxLength: 4, nullable: false),
                    Address = table.Column<string>(maxLength: 50, nullable: false),
                    City = table.Column<string>(maxLength: 25, nullable: false),
                    Anamnesis = table.Column<string>(maxLength: 255, nullable: false),
                    DiagnosisID = table.Column<int>(maxLength: 255, nullable: false),
                    Therapy = table.Column<string>(maxLength: 255, nullable: false),
                    Signet = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Protocols", x => x.ProtocolID);
                    table.ForeignKey(
                        name: "FK_Protocols_Patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Protocols_PatientID",
                table: "Protocols",
                column: "PatientID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Protocols");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
