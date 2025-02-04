using System;
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
                name: "TBL_BOOK",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "NVARCHAR(200)", maxLength: 200, nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Documento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Edicao = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    AnoPublicacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_BOOK", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EUsuario = table.Column<int>(type: "int", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBL_BOOK_ATHOR",
                columns: table => new
                {
                    Book = table.Column<int>(type: "int", nullable: false),
                    Athor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_BOOK_ATHOR", x => new { x.Book, x.Athor });
                    table.ForeignKey(
                        name: "FK_BookAthor_Athor",
                        column: x => x.Athor,
                        principalTable: "TBL_ATHOR",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookAthor_Book",
                        column: x => x.Book,
                        principalTable: "TBL_BOOK",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBL_BOOK_CATEGORY",
                columns: table => new
                {
                    Book = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_BOOK_CATEGORY", x => new { x.Book, x.Category });
                    table.ForeignKey(
                        name: "FK_BookCategory_Book",
                        column: x => x.Book,
                        principalTable: "TBL_BOOK",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookCategory_Category",
                        column: x => x.Category,
                        principalTable: "TBL_CATEGORY",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateIndex(
                name: "IX_TBL_BOOK_ATHOR_Athor",
                table: "TBL_BOOK_ATHOR",
                column: "Athor");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_BOOK_CATEGORY_Category",
                table: "TBL_BOOK_CATEGORY",
                column: "Category");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_BOOK_ATHOR");

            migrationBuilder.DropTable(
                name: "TBL_BOOK_CATEGORY");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "TBL_ATHOR");

            migrationBuilder.DropTable(
                name: "TBL_BOOK");

            migrationBuilder.DropTable(
                name: "TBL_CATEGORY");
        }
    }
}
