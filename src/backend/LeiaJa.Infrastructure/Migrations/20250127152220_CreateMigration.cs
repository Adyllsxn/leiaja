using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeiaJa.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBL_LIVROS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Autor = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Editora = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    AnoPublicacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Edicao = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_LIVROS", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TBL_LIVROS",
                columns: new[] { "Id", "AnoPublicacao", "Autor", "Edicao", "Editora", "Nome" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Roberto Kiyosaki", "02", "RPO", "Pai Pobre, PaiRico" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_LIVROS");
        }
    }
}
