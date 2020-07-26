using Microsoft.EntityFrameworkCore.Migrations;

namespace DentalInformationSystem.Data.Migrations
{
    public partial class AddTherapyTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TherapyID",
                table: "Protocols",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Therapies",
                columns: table => new
                {
                    TherapyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TherapyName = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Therapies", x => x.TherapyID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Protocols_TherapyID",
                table: "Protocols",
                column: "TherapyID");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Protocols_Therapies_TherapyID",
            //    table: "Protocols",
            //    column: "TherapyID",
            //    principalTable: "Therapies",
            //    principalColumn: "TherapyID",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Protocols_Therapies_TherapyID",
                table: "Protocols");

            migrationBuilder.DropTable(
                name: "Therapies");

            migrationBuilder.DropIndex(
                name: "IX_Protocols_TherapyID",
                table: "Protocols");

            migrationBuilder.DropColumn(
                name: "TherapyID",
                table: "Protocols");
        }
    }
}
