using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Livros.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autores",
                columns: table => new
                {
                    IdAutor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeAutor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NacionalidadeAutor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.IdAutor);
                });

            migrationBuilder.CreateTable(
                name: "Editoras",
                columns: table => new
                {
                    IdEditora = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeEditora = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocalizacaoEditora = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editoras", x => x.IdEditora);
                });

            migrationBuilder.CreateTable(
                name: "Livros",
                columns: table => new
                {
                    IdLivro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TituloLivro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnoPublicacaoLivro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livros", x => x.IdLivro);
                });

            migrationBuilder.CreateTable(
                name: "LivrosAutoresEditoras",
                columns: table => new
                {
                    IdLivroAutorEditora = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fk_LivrosID = table.Column<int>(type: "int", nullable: false),
                    fk_AutorID = table.Column<int>(type: "int", nullable: false),
                    fk_EditoraID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivrosAutoresEditoras", x => x.IdLivroAutorEditora);
                    table.ForeignKey(
                        name: "FK_LivrosAutoresEditoras_Autores_fk_AutorID",
                        column: x => x.fk_AutorID,
                        principalTable: "Autores",
                        principalColumn: "IdAutor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LivrosAutoresEditoras_Editoras_fk_EditoraID",
                        column: x => x.fk_EditoraID,
                        principalTable: "Editoras",
                        principalColumn: "IdEditora",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LivrosAutoresEditoras_Livros_fk_LivrosID",
                        column: x => x.fk_LivrosID,
                        principalTable: "Livros",
                        principalColumn: "IdLivro",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LivrosAutoresEditoras_fk_AutorID",
                table: "LivrosAutoresEditoras",
                column: "fk_AutorID");

            migrationBuilder.CreateIndex(
                name: "IX_LivrosAutoresEditoras_fk_EditoraID",
                table: "LivrosAutoresEditoras",
                column: "fk_EditoraID");

            migrationBuilder.CreateIndex(
                name: "IX_LivrosAutoresEditoras_fk_LivrosID",
                table: "LivrosAutoresEditoras",
                column: "fk_LivrosID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LivrosAutoresEditoras");

            migrationBuilder.DropTable(
                name: "Autores");

            migrationBuilder.DropTable(
                name: "Editoras");

            migrationBuilder.DropTable(
                name: "Livros");
        }
    }
}
