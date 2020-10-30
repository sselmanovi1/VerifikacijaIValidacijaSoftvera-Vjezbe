using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EBANK.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administrator",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: false),
                    Prezime = table.Column<string>(nullable: false),
                    KorisnickoIme = table.Column<string>(nullable: false),
                    Lozinka = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrator", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Adresa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Latitude = table.Column<float>(nullable: false),
                    Longitude = table.Column<float>(nullable: false),
                    Naziv = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Novost",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VrijemeDodavanja = table.Column<DateTime>(nullable: false),
                    Naslov = table.Column<string>(nullable: false),
                    Sadrzaj = table.Column<string>(nullable: false),
                    Prikazana = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Novost", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bankar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: false),
                    Prezime = table.Column<string>(nullable: false),
                    KorisnickoIme = table.Column<string>(nullable: false),
                    Lozinka = table.Column<string>(nullable: false),
                    MjestoZaposlenjaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bankar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bankar_Adresa_MjestoZaposlenjaId",
                        column: x => x.MjestoZaposlenjaId,
                        principalTable: "Adresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bankomat",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: false),
                    AdresaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bankomat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bankomat_Adresa_AdresaId",
                        column: x => x.AdresaId,
                        principalTable: "Adresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Filijala",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: false),
                    AdresaId = table.Column<int>(nullable: false),
                    BrojTelefona = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filijala", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Filijala_Adresa_AdresaId",
                        column: x => x.AdresaId,
                        principalTable: "Adresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Klijent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: false),
                    Prezime = table.Column<string>(nullable: false),
                    KorisnickoIme = table.Column<string>(nullable: false),
                    Lozinka = table.Column<string>(nullable: false),
                    DatumRodjenja = table.Column<DateTime>(nullable: false),
                    Spol = table.Column<int>(nullable: false),
                    JMBG = table.Column<string>(nullable: false),
                    BrojTelefona = table.Column<string>(nullable: false),
                    BrojLicneKarte = table.Column<string>(nullable: false),
                    AdresaId = table.Column<int>(nullable: false),
                    Zanimanje = table.Column<string>(nullable: false),
                    Grad = table.Column<string>(nullable: true),
                    Drzava = table.Column<string>(nullable: true),
                    VrijemeDodavanja = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klijent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Klijent_Adresa_AdresaId",
                        column: x => x.AdresaId,
                        principalTable: "Adresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Racun",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StanjeRacuna = table.Column<float>(nullable: false),
                    VrstaRacuna = table.Column<int>(nullable: false),
                    KlijentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Racun", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Racun_Klijent_KlijentId",
                        column: x => x.KlijentId,
                        principalTable: "Klijent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kredit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RacunId = table.Column<int>(nullable: true),
                    Iznos = table.Column<float>(nullable: false),
                    KamatnaStopa = table.Column<float>(nullable: false),
                    RokOtplate = table.Column<int>(nullable: false),
                    IsplaceniIznos = table.Column<float>(nullable: false),
                    PocetakOtplate = table.Column<DateTime>(nullable: false),
                    StatusKredita = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kredit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kredit_Racun_RacunId",
                        column: x => x.RacunId,
                        principalTable: "Racun",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transakcija",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vrijeme = table.Column<DateTime>(nullable: false),
                    SaRacunaId = table.Column<int>(nullable: false),
                    NaRacunId = table.Column<int>(nullable: false),
                    Iznos = table.Column<float>(nullable: false),
                    VrstaTransakcije = table.Column<int>(nullable: false),
                    NacinTransakcije = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transakcija", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transakcija_Racun_NaRacunId",
                        column: x => x.NaRacunId,
                        principalTable: "Racun",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Transakcija_Racun_SaRacunaId",
                        column: x => x.SaRacunaId,
                        principalTable: "Racun",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ZahtjevZaKredit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RacunId = table.Column<int>(nullable: true),
                    Iznos = table.Column<float>(nullable: false),
                    KamatnaStopa = table.Column<float>(nullable: false),
                    RokOtplate = table.Column<int>(nullable: false),
                    NamjenaKredita = table.Column<string>(nullable: false),
                    MjesecniPrihodi = table.Column<float>(nullable: false),
                    ProsjecniTroskoviDomacinstva = table.Column<float>(nullable: false),
                    NazivRadnogMjesta = table.Column<string>(nullable: false),
                    NazivPoslodavca = table.Column<string>(nullable: false),
                    RadniStaz = table.Column<int>(nullable: false),
                    BrojNekretnina = table.Column<int>(nullable: false),
                    BracnoStanje = table.Column<int>(nullable: false),
                    SupruznikIme = table.Column<string>(nullable: true),
                    SupruznikPrezime = table.Column<string>(nullable: true),
                    SupruznikZanimanje = table.Column<string>(nullable: true),
                    ImaNeplacenihDugova = table.Column<bool>(nullable: false),
                    BrojNeplacenihDugova = table.Column<float>(nullable: false),
                    StatusZahtjeva = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZahtjevZaKredit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ZahtjevZaKredit_Racun_RacunId",
                        column: x => x.RacunId,
                        principalTable: "Racun",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bankar_MjestoZaposlenjaId",
                table: "Bankar",
                column: "MjestoZaposlenjaId");

            migrationBuilder.CreateIndex(
                name: "IX_Bankomat_AdresaId",
                table: "Bankomat",
                column: "AdresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Filijala_AdresaId",
                table: "Filijala",
                column: "AdresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Klijent_AdresaId",
                table: "Klijent",
                column: "AdresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Kredit_RacunId",
                table: "Kredit",
                column: "RacunId");

            migrationBuilder.CreateIndex(
                name: "IX_Racun_KlijentId",
                table: "Racun",
                column: "KlijentId");

            migrationBuilder.CreateIndex(
                name: "IX_Transakcija_NaRacunId",
                table: "Transakcija",
                column: "NaRacunId");

            migrationBuilder.CreateIndex(
                name: "IX_Transakcija_SaRacunaId",
                table: "Transakcija",
                column: "SaRacunaId");

            migrationBuilder.CreateIndex(
                name: "IX_ZahtjevZaKredit_RacunId",
                table: "ZahtjevZaKredit",
                column: "RacunId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrator");

            migrationBuilder.DropTable(
                name: "Bankar");

            migrationBuilder.DropTable(
                name: "Bankomat");

            migrationBuilder.DropTable(
                name: "Filijala");

            migrationBuilder.DropTable(
                name: "Kredit");

            migrationBuilder.DropTable(
                name: "Novost");

            migrationBuilder.DropTable(
                name: "Transakcija");

            migrationBuilder.DropTable(
                name: "ZahtjevZaKredit");

            migrationBuilder.DropTable(
                name: "Racun");

            migrationBuilder.DropTable(
                name: "Klijent");

            migrationBuilder.DropTable(
                name: "Adresa");
        }
    }
}
