using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentskiDom.Migrations
{
    public partial class OneMoreZahtjevAddedToDBv5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Paviljon1Id",
                table: "Zahtjev",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Paviljon2Id",
                table: "Zahtjev",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RazlogPremjestanja",
                table: "Zahtjev",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Soba1Id",
                table: "Zahtjev",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Soba2Id",
                table: "Zahtjev",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Zahtjev_Paviljon1Id",
                table: "Zahtjev",
                column: "Paviljon1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Zahtjev_Paviljon2Id",
                table: "Zahtjev",
                column: "Paviljon2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Zahtjev_Soba1Id",
                table: "Zahtjev",
                column: "Soba1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Zahtjev_Soba2Id",
                table: "Zahtjev",
                column: "Soba2Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Zahtjev_Paviljon_Paviljon1Id",
                table: "Zahtjev",
                column: "Paviljon1Id",
                principalTable: "Paviljon",
                principalColumn: "PaviljonId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Zahtjev_Paviljon_Paviljon2Id",
                table: "Zahtjev",
                column: "Paviljon2Id",
                principalTable: "Paviljon",
                principalColumn: "PaviljonId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Zahtjev_Soba_Soba1Id",
                table: "Zahtjev",
                column: "Soba1Id",
                principalTable: "Soba",
                principalColumn: "SobaId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Zahtjev_Soba_Soba2Id",
                table: "Zahtjev",
                column: "Soba2Id",
                principalTable: "Soba",
                principalColumn: "SobaId",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zahtjev_Paviljon_Paviljon1Id",
                table: "Zahtjev");

            migrationBuilder.DropForeignKey(
                name: "FK_Zahtjev_Paviljon_Paviljon2Id",
                table: "Zahtjev");

            migrationBuilder.DropForeignKey(
                name: "FK_Zahtjev_Soba_Soba1Id",
                table: "Zahtjev");

            migrationBuilder.DropForeignKey(
                name: "FK_Zahtjev_Soba_Soba2Id",
                table: "Zahtjev");

            migrationBuilder.DropIndex(
                name: "IX_Zahtjev_Paviljon1Id",
                table: "Zahtjev");

            migrationBuilder.DropIndex(
                name: "IX_Zahtjev_Paviljon2Id",
                table: "Zahtjev");

            migrationBuilder.DropIndex(
                name: "IX_Zahtjev_Soba1Id",
                table: "Zahtjev");

            migrationBuilder.DropIndex(
                name: "IX_Zahtjev_Soba2Id",
                table: "Zahtjev");

            migrationBuilder.DropColumn(
                name: "Paviljon1Id",
                table: "Zahtjev");

            migrationBuilder.DropColumn(
                name: "Paviljon2Id",
                table: "Zahtjev");

            migrationBuilder.DropColumn(
                name: "RazlogPremjestanja",
                table: "Zahtjev");

            migrationBuilder.DropColumn(
                name: "Soba1Id",
                table: "Zahtjev");

            migrationBuilder.DropColumn(
                name: "Soba2Id",
                table: "Zahtjev");
        }
    }
}
