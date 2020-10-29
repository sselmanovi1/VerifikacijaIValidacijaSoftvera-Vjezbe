using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentskiDom.Migrations
{
    public partial class FiftyFifty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LicniPodaci",
                columns: table => new
                {
                    LicniPodaciId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prezime = table.Column<string>(nullable: true),
                    Ime = table.Column<string>(nullable: true),
                    MjestoRodjenja = table.Column<string>(nullable: true),
                    Pol = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Jmbg = table.Column<long>(nullable: false),
                    DatumRodjenja = table.Column<DateTime>(nullable: false),
                    Mobitel = table.Column<int>(nullable: false),
                    Slika = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicniPodaci", x => x.LicniPodaciId);
                });

            migrationBuilder.CreateTable(
                name: "PrebivalisteInfo",
                columns: table => new
                {
                    PrebivalisteInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adresa = table.Column<string>(nullable: true),
                    Kanton = table.Column<string>(nullable: true),
                    Opcina = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrebivalisteInfo", x => x.PrebivalisteInfoId);
                });

            migrationBuilder.CreateTable(
                name: "SkolovanjeInfo",
                columns: table => new
                {
                    SkolovanjeInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fakultet = table.Column<string>(nullable: true),
                    BrojIndeksa = table.Column<int>(nullable: false),
                    CiklusStudija = table.Column<int>(nullable: false),
                    GodinaStudija = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkolovanjeInfo", x => x.SkolovanjeInfoId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_LicniPodaciId",
                table: "Korisnik",
                column: "LicniPodaciId",
                unique: true,
                filter: "[LicniPodaciId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_PrebivalisteInfoId",
                table: "Korisnik",
                column: "PrebivalisteInfoId",
                unique: true,
                filter: "[PrebivalisteInfoId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_SkolovanjeInfoId",
                table: "Korisnik",
                column: "SkolovanjeInfoId",
                unique: true,
                filter: "[SkolovanjeInfoId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Korisnik_LicniPodaci_LicniPodaciId",
                table: "Korisnik",
                column: "LicniPodaciId",
                principalTable: "LicniPodaci",
                principalColumn: "LicniPodaciId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Korisnik_PrebivalisteInfo_PrebivalisteInfoId",
                table: "Korisnik",
                column: "PrebivalisteInfoId",
                principalTable: "PrebivalisteInfo",
                principalColumn: "PrebivalisteInfoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Korisnik_SkolovanjeInfo_SkolovanjeInfoId",
                table: "Korisnik",
                column: "SkolovanjeInfoId",
                principalTable: "SkolovanjeInfo",
                principalColumn: "SkolovanjeInfoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Korisnik_LicniPodaci_LicniPodaciId",
                table: "Korisnik");

            migrationBuilder.DropForeignKey(
                name: "FK_Korisnik_PrebivalisteInfo_PrebivalisteInfoId",
                table: "Korisnik");

            migrationBuilder.DropForeignKey(
                name: "FK_Korisnik_SkolovanjeInfo_SkolovanjeInfoId",
                table: "Korisnik");

            migrationBuilder.DropTable(
                name: "LicniPodaci");

            migrationBuilder.DropTable(
                name: "PrebivalisteInfo");

            migrationBuilder.DropTable(
                name: "SkolovanjeInfo");

            migrationBuilder.DropIndex(
                name: "IX_Korisnik_LicniPodaciId",
                table: "Korisnik");

            migrationBuilder.DropIndex(
                name: "IX_Korisnik_PrebivalisteInfoId",
                table: "Korisnik");

            migrationBuilder.DropIndex(
                name: "IX_Korisnik_SkolovanjeInfoId",
                table: "Korisnik");
        }
    }
}
