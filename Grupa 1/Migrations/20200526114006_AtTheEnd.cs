using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentskiDom.Migrations
{
    public partial class AtTheEnd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Namirnica",
                columns: table => new
                {
                    NamirnicaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    ZahtjevZaNabavkuNamirnicaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Namirnica", x => x.NamirnicaId);
                });

            migrationBuilder.CreateTable(
                name: "Paviljon",
                columns: table => new
                {
                    PaviljonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    Kapacitet = table.Column<int>(nullable: false),
                    BrojStudenata = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paviljon", x => x.PaviljonId);
                });

            migrationBuilder.CreateTable(
                name: "StavkaNarudzbe",
                columns: table => new
                {
                    StavkaNarudzbeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kolicina = table.Column<double>(nullable: false),
                    ZahtjevZaNabavkuNamirnicaId = table.Column<int>(nullable: true),
                    NamirnicaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StavkaNarudzbe", x => x.StavkaNarudzbeId);
                    table.ForeignKey(
                        name: "FK_StavkaNarudzbe_Namirnica_NamirnicaId",
                        column: x => x.NamirnicaId,
                        principalTable: "Namirnica",
                        principalColumn: "NamirnicaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Soba",
                columns: table => new
                {
                    SobaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojSobe = table.Column<int>(nullable: false),
                    Kapacitet = table.Column<int>(nullable: false),
                    PaviljonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Soba", x => x.SobaId);
                    table.ForeignKey(
                        name: "FK_Soba_Paviljon_PaviljonId",
                        column: x => x.PaviljonId,
                        principalTable: "Paviljon",
                        principalColumn: "PaviljonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_SobaId",
                table: "Korisnik",
                column: "SobaId");

            migrationBuilder.CreateIndex(
                name: "IX_Soba_PaviljonId",
                table: "Soba",
                column: "PaviljonId");

            migrationBuilder.CreateIndex(
                name: "IX_StavkaNarudzbe_NamirnicaId",
                table: "StavkaNarudzbe",
                column: "NamirnicaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Korisnik_Soba_SobaId",
                table: "Korisnik",
                column: "SobaId",
                principalTable: "Soba",
                principalColumn: "SobaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Korisnik_Soba_SobaId",
                table: "Korisnik");

            migrationBuilder.DropTable(
                name: "Soba");

            migrationBuilder.DropTable(
                name: "StavkaNarudzbe");

            migrationBuilder.DropTable(
                name: "Paviljon");

            migrationBuilder.DropTable(
                name: "Namirnica");

            migrationBuilder.DropIndex(
                name: "IX_Korisnik_SobaId",
                table: "Korisnik");
        }
    }
}
