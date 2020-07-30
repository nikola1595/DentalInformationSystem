using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DentalInformationSystem.Data.Migrations
{
    public partial class RenameProcurmentFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Procurements",
                table: "Procurements");

            migrationBuilder.DropColumn(
                name: "ProcurmentID",
                table: "Procurements");

            migrationBuilder.DropColumn(
                name: "ProcurmentDate",
                table: "Procurements");

            migrationBuilder.AddColumn<int>(
                name: "ProcurementID",
                table: "Procurements",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "ProcurementDate",
                table: "Procurements",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Procurements",
                table: "Procurements",
                column: "ProcurementID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Procurements",
                table: "Procurements");

            migrationBuilder.DropColumn(
                name: "ProcurementID",
                table: "Procurements");

            migrationBuilder.DropColumn(
                name: "ProcurementDate",
                table: "Procurements");

            migrationBuilder.AddColumn<int>(
                name: "ProcurmentID",
                table: "Procurements",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "ProcurmentDate",
                table: "Procurements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Procurements",
                table: "Procurements",
                column: "ProcurmentID");
        }
    }
}
