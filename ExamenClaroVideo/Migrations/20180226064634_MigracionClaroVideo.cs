using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamenClaroVideo.Migrations
{
    public partial class MigracionClaroVideo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Estado = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Peliculas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Actor = table.Column<string>(nullable: true),
                    Clasificacion = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    Director = table.Column<string>(nullable: true),
                    Duracion = table.Column<string>(nullable: true),
                    Escritor = table.Column<string>(nullable: true),
                    Estado = table.Column<int>(nullable: false),
                    Genero = table.Column<string>(nullable: true),
                    Productor = table.Column<string>(nullable: true),
                    RutaImagen = table.Column<string>(nullable: true),
                    Titulo = table.Column<string>(nullable: true),
                    TítuloOriginal = table.Column<string>(nullable: true),
                    UrlImagen = table.Column<string>(nullable: true),
                    UrlVideo = table.Column<string>(nullable: true),
                    VideoLocal = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peliculas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RelacionCatPel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoriaId = table.Column<int>(nullable: true),
                    PeliculaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelacionCatPel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RelacionCatPel_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RelacionCatPel_Peliculas_PeliculaId",
                        column: x => x.PeliculaId,
                        principalTable: "Peliculas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RelacionCatPel_CategoriaId",
                table: "RelacionCatPel",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_RelacionCatPel_PeliculaId",
                table: "RelacionCatPel",
                column: "PeliculaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RelacionCatPel");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Peliculas");
        }
    }
}
