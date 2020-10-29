using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentskiDom.Migrations
{
    public partial class ConnectionRestoranZahtjev : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Zahtjev_RestoranId",
                table: "Zahtjev");

            migrationBuilder.CreateIndex(
                name: "IX_Zahtjev_RestoranId",
                table: "Zahtjev",
                column: "RestoranId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Zahtjev_RestoranId",
                table: "Zahtjev");

            migrationBuilder.CreateIndex(
                name: "IX_Zahtjev_RestoranId",
                table: "Zahtjev",
                column: "RestoranId",
                unique: true,
                filter: "[RestoranId] IS NOT NULL");
        }
    }
}
