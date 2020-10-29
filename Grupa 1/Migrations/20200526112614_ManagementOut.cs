using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentskiDom.Migrations
{
    public partial class ManagementOut : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KorisnikId",
                table: "Korisnik",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Blagajna",
                columns: table => new
                {
                    BlagajnaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StanjeBudgeta = table.Column<double>(nullable: false),
                    UpravaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blagajna", x => x.BlagajnaId);
                    table.ForeignKey(
                        name: "FK_Blagajna_Korisnik_UpravaId",
                        column: x => x.UpravaId,
                        principalTable: "Korisnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blagajna_UpravaId",
                table: "Blagajna",
                column: "UpravaId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blagajna");

            migrationBuilder.DropColumn(
                name: "KorisnikId",
                table: "Korisnik");
        }
    }
}
