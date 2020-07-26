using Microsoft.EntityFrameworkCore.Migrations;

namespace DentalInformationSystem.Data.Migrations
{
    public partial class AddAnamnesisTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Anamnesis",
                table: "Protocols");

            migrationBuilder.AddColumn<int>(
                name: "AnamnesisID",
                table: "Protocols",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Anamneses",
                columns: table => new
                {
                    AnamnesisID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnamnesisName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anamneses", x => x.AnamnesisID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Protocols_AnamnesisID",
                table: "Protocols",
                column: "AnamnesisID");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Protocols_Anamneses_AnamnesisID",
            //    table: "Protocols",
            //    column: "AnamnesisID",
            //    principalTable: "Anamneses",
            //    principalColumn: "AnamnesisID",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Protocols_Anamneses_AnamnesisID",
                table: "Protocols");

            migrationBuilder.DropTable(
                name: "Anamneses");

            migrationBuilder.DropIndex(
                name: "IX_Protocols_AnamnesisID",
                table: "Protocols");

            migrationBuilder.DropColumn(
                name: "AnamnesisID",
                table: "Protocols");

            migrationBuilder.AddColumn<string>(
                name: "Anamnesis",
                table: "Protocols",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }
    }
}
