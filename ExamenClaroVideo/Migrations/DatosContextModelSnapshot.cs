using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ExamenClaroVideo.DataLayer;

namespace ExamenClaroVideo.Migrations
{
    [DbContext(typeof(DatosContext))]
    partial class DatosContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.3");

            modelBuilder.Entity("ExamenClaroVideo.DataLayer.Entities.Db_Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Estado");

                    b.Property<string>("Nombre");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("ExamenClaroVideo.DataLayer.Entities.Db_Peliculas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Actor");

                    b.Property<string>("Clasificacion");

                    b.Property<string>("Descripcion");

                    b.Property<string>("Director");

                    b.Property<string>("Duracion");

                    b.Property<string>("Escritor");

                    b.Property<int>("Estado");

                    b.Property<string>("Genero");

                    b.Property<string>("Productor");

                    b.Property<string>("RutaImagen");

                    b.Property<string>("Titulo");

                    b.Property<string>("TítuloOriginal");

                    b.Property<string>("UrlImagen");

                    b.Property<string>("UrlVideo");

                    b.Property<string>("VideoLocal");

                    b.HasKey("Id");

                    b.ToTable("Peliculas");
                });

            modelBuilder.Entity("ExamenClaroVideo.DataLayer.Entities.Db_RelacionCatPel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CategoriaId");

                    b.Property<int?>("PeliculaId");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("PeliculaId");

                    b.ToTable("RelacionCatPel");
                });

            modelBuilder.Entity("ExamenClaroVideo.DataLayer.Entities.Db_RelacionCatPel", b =>
                {
                    b.HasOne("ExamenClaroVideo.DataLayer.Entities.Db_Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId");

                    b.HasOne("ExamenClaroVideo.DataLayer.Entities.Db_Peliculas", "Pelicula")
                        .WithMany()
                        .HasForeignKey("PeliculaId");
                });
        }
    }
}
