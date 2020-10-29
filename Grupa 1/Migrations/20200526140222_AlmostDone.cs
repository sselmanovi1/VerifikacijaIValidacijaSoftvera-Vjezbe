using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentskiDom.Migrations
{
    public partial class AlmostDone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Korisnik_Korisnik_StudentId1",
                table: "Korisnik");

            migrationBuilder.DropIndex(
                name: "IX_Korisnik_StudentId1",
                table: "Korisnik");

            migrationBuilder.DropColumn(
                name: "StudentId1",
                table: "Korisnik");

            migrationBuilder.CreateTable(
                name: "Zahtjev",
                columns: table => new
                {
                    ZahtjevId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<DateTime>(nullable: false),
                    Odobren = table.Column<bool>(nullable: false),
                    ZahtjevRestoranaZahtjevId = table.Column<int>(nullable: true),
                    ZahtjevStudentaZahtjevId = table.Column<int>(nullable: true),
                    ZahtjevZaUpisZahtjevId = table.Column<int>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    RestoranId = table.Column<int>(nullable: true),
                    StudentId = table.Column<int>(nullable: true),
                    LicniPodaciId = table.Column<int>(nullable: true),
                    PrebivalisteInfoId = table.Column<int>(nullable: true),
                    SkolovanjeInfoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zahtjev", x => x.ZahtjevId);
                    table.ForeignKey(
                        name: "FK_Zahtjev_Zahtjev_ZahtjevRestoranaZahtjevId",
                        column: x => x.ZahtjevRestoranaZahtjevId,
                        principalTable: "Zahtjev",
                        principalColumn: "ZahtjevId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Zahtjev_Zahtjev_ZahtjevStudentaZahtjevId",
                        column: x => x.ZahtjevStudentaZahtjevId,
                        principalTable: "Zahtjev",
                        principalColumn: "ZahtjevId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Zahtjev_Zahtjev_ZahtjevZaUpisZahtjevId",
                        column: x => x.ZahtjevZaUpisZahtjevId,
                        principalTable: "Zahtjev",
                        principalColumn: "ZahtjevId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Zahtjev_Korisnik_RestoranId",
                        column: x => x.RestoranId,
                        principalTable: "Korisnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zahtjev_Korisnik_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Korisnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Zahtjev_LicniPodaci_LicniPodaciId",
                        column: x => x.LicniPodaciId,
                        principalTable: "LicniPodaci",
                        principalColumn: "LicniPodaciId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Zahtjev_PrebivalisteInfo_PrebivalisteInfoId",
                        column: x => x.PrebivalisteInfoId,
                        principalTable: "PrebivalisteInfo",
                        principalColumn: "PrebivalisteInfoId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Zahtjev_SkolovanjeInfo_SkolovanjeInfoId",
                        column: x => x.SkolovanjeInfoId,
                        principalTable: "SkolovanjeInfo",
                        principalColumn: "SkolovanjeInfoId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_StudentId",
                table: "Korisnik",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_KorisnikId",
                table: "Korisnik",
                column: "KorisnikId",
                unique: true,
                filter: "[KorisnikId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Zahtjev_ZahtjevRestoranaZahtjevId",
                table: "Zahtjev",
                column: "ZahtjevRestoranaZahtjevId");

            migrationBuilder.CreateIndex(
                name: "IX_Zahtjev_ZahtjevStudentaZahtjevId",
                table: "Zahtjev",
                column: "ZahtjevStudentaZahtjevId");

            migrationBuilder.CreateIndex(
                name: "IX_Zahtjev_ZahtjevZaUpisZahtjevId",
                table: "Zahtjev",
                column: "ZahtjevZaUpisZahtjevId");

            migrationBuilder.CreateIndex(
                name: "IX_Zahtjev_RestoranId",
                table: "Zahtjev",
                column: "RestoranId",
                unique: true,
                filter: "[RestoranId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Zahtjev_StudentId",
                table: "Zahtjev",
                column: "StudentId",
                unique: true,
                filter: "[StudentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Zahtjev_LicniPodaciId",
                table: "Zahtjev",
                column: "LicniPodaciId",
                unique: true,
                filter: "[LicniPodaciId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Zahtjev_PrebivalisteInfoId",
                table: "Zahtjev",
                column: "PrebivalisteInfoId",
                unique: true,
                filter: "[PrebivalisteInfoId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Zahtjev_SkolovanjeInfoId",
                table: "Zahtjev",
                column: "SkolovanjeInfoId",
                unique: true,
                filter: "[SkolovanjeInfoId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Korisnik_Korisnik_StudentId",
                table: "Korisnik",
                column: "StudentId",
                principalTable: "Korisnik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Korisnik_Korisnik_KorisnikId",
                table: "Korisnik",
                column: "KorisnikId",
                principalTable: "Korisnik",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Korisnik_Korisnik_StudentId",
                table: "Korisnik");

            migrationBuilder.DropForeignKey(
                name: "FK_Korisnik_Korisnik_KorisnikId",
                table: "Korisnik");

            migrationBuilder.DropTable(
                name: "Zahtjev");

            migrationBuilder.DropIndex(
                name: "IX_Korisnik_StudentId",
                table: "Korisnik");

            migrationBuilder.DropIndex(
                name: "IX_Korisnik_KorisnikId",
                table: "Korisnik");

            migrationBuilder.AddColumn<int>(
                name: "StudentId1",
                table: "Korisnik",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_StudentId1",
                table: "Korisnik",
                column: "StudentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Korisnik_Korisnik_StudentId1",
                table: "Korisnik",
                column: "StudentId1",
                principalTable: "Korisnik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
