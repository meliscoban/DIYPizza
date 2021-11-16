using Microsoft.EntityFrameworkCore.Migrations;

namespace DIYPizza.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Malzemeler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Malzemeler", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Malzemeler",
                columns: new[] { "Id", "Ad" },
                values: new object[,]
                {
                    { 1, "Mozzarella" },
                    { 18, "Tavuk" },
                    { 17, "Soğan" },
                    { 16, "Füme" },
                    { 15, "Kavurma" },
                    { 14, "Kaşar" },
                    { 13, "Rokfor" },
                    { 12, "Ton Balığı" },
                    { 11, "Ananas" },
                    { 10, "Pastırma" },
                    { 9, "Mantar" },
                    { 8, "Biber" },
                    { 7, "Sosis" },
                    { 6, "Sucuk" },
                    { 5, "Salam" },
                    { 4, "Zeytin" },
                    { 3, "Mısır" },
                    { 2, "Pizza Sosu" },
                    { 19, "Parmesan" },
                    { 20, "Domates" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Malzemeler");
        }
    }
}
