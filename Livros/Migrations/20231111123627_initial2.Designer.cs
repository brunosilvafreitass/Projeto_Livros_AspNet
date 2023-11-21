﻿// <auto-generated />
using System;
using Livros.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Livros.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20231111123627_initial2")]
    partial class initial2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Livros.Models.AutoresModel", b =>
                {
                    b.Property<int?>("IdAutor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("IdAutor"));

                    b.Property<string>("NacionalidadeAutor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeAutor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdAutor");

                    b.ToTable("Autores");
                });

            modelBuilder.Entity("Livros.Models.EditorasModel", b =>
                {
                    b.Property<int?>("IdEditora")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("IdEditora"));

                    b.Property<string>("LocalizacaoEditora")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeEditora")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEditora");

                    b.ToTable("Editoras");
                });

            modelBuilder.Entity("Livros.Models.LivroAutorEditoraModel", b =>
                {
                    b.Property<int>("IdLivroAutorEditora")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdLivroAutorEditora"));

                    b.Property<int?>("fk_AutorID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("fk_EditoraID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("fk_LivrosID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("IdLivroAutorEditora");

                    b.HasIndex("fk_AutorID");

                    b.HasIndex("fk_EditoraID");

                    b.HasIndex("fk_LivrosID");

                    b.ToTable("LivrosAutoresEditoras");
                });

            modelBuilder.Entity("Livros.Models.LivrosModel", b =>
                {
                    b.Property<int?>("IdLivro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("IdLivro"));

                    b.Property<DateTime>("AnoPublicacaoLivro")
                        .HasColumnType("datetime2");

                    b.Property<string>("TituloLivro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdLivro");

                    b.ToTable("Livros");
                });

            modelBuilder.Entity("Livros.Models.LivroAutorEditoraModel", b =>
                {
                    b.HasOne("Livros.Models.AutoresModel", "Autores")
                        .WithMany("AutorEditors")
                        .HasForeignKey("fk_AutorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Livros.Models.EditorasModel", "Editoras")
                        .WithMany("AutorEditors")
                        .HasForeignKey("fk_EditoraID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Livros.Models.LivrosModel", "Livros")
                        .WithMany("AutorEditors")
                        .HasForeignKey("fk_LivrosID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Autores");

                    b.Navigation("Editoras");

                    b.Navigation("Livros");
                });

            modelBuilder.Entity("Livros.Models.AutoresModel", b =>
                {
                    b.Navigation("AutorEditors");
                });

            modelBuilder.Entity("Livros.Models.EditorasModel", b =>
                {
                    b.Navigation("AutorEditors");
                });

            modelBuilder.Entity("Livros.Models.LivrosModel", b =>
                {
                    b.Navigation("AutorEditors");
                });
#pragma warning restore 612, 618
        }
    }
}
