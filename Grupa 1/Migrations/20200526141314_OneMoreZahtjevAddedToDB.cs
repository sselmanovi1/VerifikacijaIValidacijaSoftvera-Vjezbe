using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentskiDom.Migrations
{
    public partial class OneMoreZahtjevAddedToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_StavkaNarudzbe_ZahtjevZaNabavkuNamirnicaId",
                table: "StavkaNarudzbe",
                column: "ZahtjevZaNabavkuNamirnicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Namirnica_ZahtjevZaNabavkuNamirnicaId",
                table: "Namirnica",
                column: "ZahtjevZaNabavkuNamirnicaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Namirnica_Zahtjev_ZahtjevZaNabavkuNamirnicaId",
                table: "Namirnica",
                column: "ZahtjevZaNabavkuNamirnicaId",
                principalTable: "Zahtjev",
                principalColumn: "ZahtjevId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StavkaNarudzbe_Zahtjev_ZahtjevZaNabavkuNamirnicaId",
                table: "StavkaNarudzbe",
                column: "ZahtjevZaNabavkuNamirnicaId",
                principalTable: "Zahtjev",
                principalColumn: "ZahtjevId",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Namirnica_Zahtjev_ZahtjevZaNabavkuNamirnicaId",
                table: "Namirnica");

            migrationBuilder.DropForeignKey(
                name: "FK_StavkaNarudzbe_Zahtjev_ZahtjevZaNabavkuNamirnicaId",
                table: "StavkaNarudzbe");

            migrationBuilder.DropIndex(
                name: "IX_StavkaNarudzbe_ZahtjevZaNabavkuNamirnicaId",
                table: "StavkaNarudzbe");

            migrationBuilder.DropIndex(
                name: "IX_Namirnica_ZahtjevZaNabavkuNamirnicaId",
                table: "Namirnica");
        }
    }
}
