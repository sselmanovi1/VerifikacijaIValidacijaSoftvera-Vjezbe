using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentskiDom.Migrations
{
    public partial class Bismillah3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    StudentId1 = table.Column<int>(nullable: true),
                    RestoranId = table.Column<int>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    DnevniMeniId = table.Column<int>(nullable: true),
                    StudentId = table.Column<int>(nullable: true),
                    BrojRucaka = table.Column<int>(nullable: true),
                    BrojVecera = table.Column<int>(nullable: true),
                    LicniPodaciId = table.Column<int>(nullable: true),
                    PrebivalisteInfoId = table.Column<int>(nullable: true),
                    SkolovanjeInfoId = table.Column<int>(nullable: true),
                    SobaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Korisnik_Korisnik_RestoranId",
                        column: x => x.RestoranId,
                        principalTable: "Korisnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Korisnik_Korisnik_StudentId1",
                        column: x => x.StudentId1,
                        principalTable: "Korisnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Korisnik_DnevniMeni_DnevniMeniId",
                        column: x => x.DnevniMeniId,
                        principalTable: "DnevniMeni",
                        principalColumn: "DnevniMeniId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_RestoranId",
                table: "Korisnik",
                column: "RestoranId");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_StudentId1",
                table: "Korisnik",
                column: "StudentId1");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_DnevniMeniId",
                table: "Korisnik",
                column: "DnevniMeniId",
                unique: true,
                filter: "[DnevniMeniId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Korisnik");
        }
    }
}
