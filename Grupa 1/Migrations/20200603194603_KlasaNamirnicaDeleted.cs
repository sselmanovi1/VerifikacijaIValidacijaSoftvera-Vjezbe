using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentskiDom.Migrations
{
    public partial class KlasaNamirnicaDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StavkaNarudzbe_Namirnica_NamirnicaId",
                table: "StavkaNarudzbe");

            migrationBuilder.DropTable(
                name: "Namirnica");

            migrationBuilder.DropIndex(
                name: "IX_StavkaNarudzbe_NamirnicaId",
                table: "StavkaNarudzbe");

            migrationBuilder.DropColumn(
                name: "NamirnicaId",
                table: "StavkaNarudzbe");

            migrationBuilder.AddColumn<string>(
                name: "Namirnica",
                table: "StavkaNarudzbe",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Namirnica",
                table: "StavkaNarudzbe");

            migrationBuilder.AddColumn<int>(
                name: "NamirnicaId",
                table: "StavkaNarudzbe",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Namirnica",
                columns: table => new
                {
                    NamirnicaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZahtjevZaNabavkuNamirnicaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Namirnica", x => x.NamirnicaId);
                    table.ForeignKey(
                        name: "FK_Namirnica_Zahtjev_ZahtjevZaNabavkuNamirnicaId",
                        column: x => x.ZahtjevZaNabavkuNamirnicaId,
                        principalTable: "Zahtjev",
                        principalColumn: "ZahtjevId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StavkaNarudzbe_NamirnicaId",
                table: "StavkaNarudzbe",
                column: "NamirnicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Namirnica_ZahtjevZaNabavkuNamirnicaId",
                table: "Namirnica",
                column: "ZahtjevZaNabavkuNamirnicaId");

            migrationBuilder.AddForeignKey(
                name: "FK_StavkaNarudzbe_Namirnica_NamirnicaId",
                table: "StavkaNarudzbe",
                column: "NamirnicaId",
                principalTable: "Namirnica",
                principalColumn: "NamirnicaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
