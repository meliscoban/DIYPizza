using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DIYPizza.Migrations
{
    public partial class siparisTablo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Siparisler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Zaman = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siparisler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MalzemeSiparis",
                columns: table => new
                {
                    MalzemelerId = table.Column<int>(type: "int", nullable: false),
                    SiparislerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MalzemeSiparis", x => new { x.MalzemelerId, x.SiparislerId });
                    table.ForeignKey(
                        name: "FK_MalzemeSiparis_Malzemeler_MalzemelerId",
                        column: x => x.MalzemelerId,
                        principalTable: "Malzemeler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MalzemeSiparis_Siparisler_SiparislerId",
                        column: x => x.SiparislerId,
                        principalTable: "Siparisler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MalzemeSiparis_SiparislerId",
                table: "MalzemeSiparis",
                column: "SiparislerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MalzemeSiparis");

            migrationBuilder.DropTable(
                name: "Siparisler");
        }
    }
}
