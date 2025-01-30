using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeiaJa.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CREATEMIGRATIONS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBL_ATHOR",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    UltimoNome = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_ATHOR", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBL_CATEGORY",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Categoria = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_CATEGORY", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TBL_CATEGORY",
                columns: new[] { "Id", "Categoria", "Descricao" },
                values: new object[,]
                {
                    { 1, "Romântico", "msnmansmnamnsman" },
                    { 2, "Desenvolvimento Pessoal", "jakdjakjsakjakljkjasj" },
                    { 3, "Finanças", "dhsjkdjskd" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_ATHOR");

            migrationBuilder.DropTable(
                name: "TBL_CATEGORY");
        }
    }
}
