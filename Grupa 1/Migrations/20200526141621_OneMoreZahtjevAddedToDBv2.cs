using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentskiDom.Migrations
{
    public partial class OneMoreZahtjevAddedToDBv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cimer1Id",
                table: "Zahtjev",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DodatneNapomene",
                table: "Zahtjev",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaviljonId",
                table: "Zahtjev",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SobaId",
                table: "Zahtjev",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Zahtjev_Cimer1Id",
                table: "Zahtjev",
                column: "Cimer1Id",
                unique: true,
                filter: "[Cimer1Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Zahtjev_PaviljonId",
                table: "Zahtjev",
                column: "PaviljonId",
                unique: true,
                filter: "[PaviljonId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Zahtjev_SobaId",
                table: "Zahtjev",
                column: "SobaId",
                unique: true,
                filter: "[SobaId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Zahtjev_Korisnik_Cimer1Id",
                table: "Zahtjev",
                column: "Cimer1Id",
                principalTable: "Korisnik",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Zahtjev_Paviljon_PaviljonId",
                table: "Zahtjev",
                column: "PaviljonId",
                principalTable: "Paviljon",
                principalColumn: "PaviljonId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Zahtjev_Soba_SobaId",
                table: "Zahtjev",
                column: "SobaId",
                principalTable: "Soba",
                principalColumn: "SobaId",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zahtjev_Korisnik_Cimer1Id",
                table: "Zahtjev");

            migrationBuilder.DropForeignKey(
                name: "FK_Zahtjev_Paviljon_PaviljonId",
                table: "Zahtjev");

            migrationBuilder.DropForeignKey(
                name: "FK_Zahtjev_Soba_SobaId",
                table: "Zahtjev");

            migrationBuilder.DropIndex(
                name: "IX_Zahtjev_Cimer1Id",
                table: "Zahtjev");

            migrationBuilder.DropIndex(
                name: "IX_Zahtjev_PaviljonId",
                table: "Zahtjev");

            migrationBuilder.DropIndex(
                name: "IX_Zahtjev_SobaId",
                table: "Zahtjev");

            migrationBuilder.DropColumn(
                name: "Cimer1Id",
                table: "Zahtjev");

            migrationBuilder.DropColumn(
                name: "DodatneNapomene",
                table: "Zahtjev");

            migrationBuilder.DropColumn(
                name: "PaviljonId",
                table: "Zahtjev");

            migrationBuilder.DropColumn(
                name: "SobaId",
                table: "Zahtjev");
        }
    }
}
