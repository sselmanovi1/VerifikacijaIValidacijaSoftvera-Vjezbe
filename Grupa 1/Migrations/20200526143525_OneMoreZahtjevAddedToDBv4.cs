using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentskiDom.Migrations
{
    public partial class OneMoreZahtjevAddedToDBv4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Zahtjev_Cimer1Id",
                table: "Zahtjev");

            migrationBuilder.AddColumn<int>(
                name: "Cimer2Id",
                table: "Zahtjev",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Zahtjev_Cimer1Id",
                table: "Zahtjev",
                column: "Cimer1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Zahtjev_Cimer2Id",
                table: "Zahtjev",
                column: "Cimer2Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Zahtjev_Korisnik_Cimer2Id",
                table: "Zahtjev",
                column: "Cimer2Id",
                principalTable: "Korisnik",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zahtjev_Korisnik_Cimer2Id",
                table: "Zahtjev");

            migrationBuilder.DropIndex(
                name: "IX_Zahtjev_Cimer1Id",
                table: "Zahtjev");

            migrationBuilder.DropIndex(
                name: "IX_Zahtjev_Cimer2Id",
                table: "Zahtjev");

            migrationBuilder.DropColumn(
                name: "Cimer2Id",
                table: "Zahtjev");

            migrationBuilder.CreateIndex(
                name: "IX_Zahtjev_Cimer1Id",
                table: "Zahtjev",
                column: "Cimer1Id",
                unique: true,
                filter: "[Cimer1Id] IS NOT NULL");
        }
    }
}
