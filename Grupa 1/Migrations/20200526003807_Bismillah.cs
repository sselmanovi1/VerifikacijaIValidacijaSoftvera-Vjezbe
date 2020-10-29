using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentskiDom.Migrations
{
    public partial class Bismillah : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DnevniMeni",
                columns: table => new
                {
                    DnevniMeniId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DnevniMeni", x => x.DnevniMeniId);
                });

            migrationBuilder.CreateTable(
                name: "Jelo",
                columns: table => new
                {
                    JeloId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    DnevniMeniId = table.Column<int>(nullable: false)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jelo");

            migrationBuilder.DropTable(
                name: "DnevniMeni");
        }
    }
}
