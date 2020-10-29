using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentskiDom.Migrations
{
    public partial class Bismillah2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jelo");

            migrationBuilder.CreateTable(
                name: "Rucak",
                columns: table => new
                {
                    RucakId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    DnevniMeniId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rucak", x => x.RucakId);
                    table.ForeignKey(
                        name: "FK_Rucak_DnevniMeni_DnevniMeniId",
                        column: x => x.DnevniMeniId,
                        principalTable: "DnevniMeni",
                        principalColumn: "DnevniMeniId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vecera",
                columns: table => new
                {
                    VeceraId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    DnevniMeniId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vecera", x => x.VeceraId);
                    table.ForeignKey(
                        name: "FK_Vecera_DnevniMeni_DnevniMeniId",
                        column: x => x.DnevniMeniId,
                        principalTable: "DnevniMeni",
                        principalColumn: "DnevniMeniId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rucak_DnevniMeniId",
                table: "Rucak",
                column: "DnevniMeniId");

            migrationBuilder.CreateIndex(
                name: "IX_Vecera_DnevniMeniId",
                table: "Vecera",
                column: "DnevniMeniId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rucak");

            migrationBuilder.DropTable(
                name: "Vecera");

            migrationBuilder.CreateTable(
                name: "Jelo",
                columns: table => new
                {
                    JeloId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DnevniMeniId = table.Column<int>(type: "int", nullable: false),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jelo", x => x.JeloId);
                    table.ForeignKey(
                        name: "FK_Jelo_DnevniMeni_DnevniMeniId",
                        column: x => x.DnevniMeniId,
                        principalTable: "DnevniMeni",
                        principalColumn: "DnevniMeniId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jelo_DnevniMeniId",
                table: "Jelo",
                column: "DnevniMeniId");
        }
    }
}
