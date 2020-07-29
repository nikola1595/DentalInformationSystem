using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DentalInformationSystem.Data.Migrations
{
    public partial class AddProcurementModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Procurements",
                columns: table => new
                {
                    ProcurmentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcurmentDate = table.Column<DateTime>(nullable: false),
                    SupplierID = table.Column<int>(nullable: false),
                    DeliveryNoteNumber = table.Column<string>(nullable: false),
                    MerchandiseName = table.Column<string>(nullable: false),
                    MeasureUnit = table.Column<string>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    TotalPrice = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procurements", x => x.ProcurmentID);
                    table.ForeignKey(
                        name: "FK_Procurements_Suppliers_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Procurements_SupplierID",
                table: "Procurements",
                column: "SupplierID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Procurements");
        }
    }
}
