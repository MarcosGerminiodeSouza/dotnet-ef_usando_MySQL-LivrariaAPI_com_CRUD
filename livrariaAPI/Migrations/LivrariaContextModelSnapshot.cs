﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using livrariaAPI.Context;

#nullable disable

namespace LivrariaAPI.Migrations
{
    [DbContext(typeof(LivrariaContext))]
    partial class LivrariaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("livrariaAPI.Models.Entities.Autor", b =>
                {
                    b.Property<int>("idt_autor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("nom_autor")
                        .HasColumnType("varchar(45)");

                    b.HasKey("idt_autor");

                    b.ToTable("Autores");
                });

            modelBuilder.Entity("livrariaAPI.Models.Entities.Categoria", b =>
                {
                    b.Property<int>("idt_categoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("des_categoria")
                        .HasColumnType("varchar(45)");

                    b.HasKey("idt_categoria");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("livrariaAPI.Models.Entities.Editora", b =>
                {
                    b.Property<int>("idt_editora")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("nom_editora")
                        .HasColumnType("varchar(45)");

                    b.HasKey("idt_editora");

                    b.ToTable("Editoras");
                });

            modelBuilder.Entity("livrariaAPI.Models.Entities.Livro", b =>
                {
                    b.Property<int>("idt_livro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("des_imagem")
                        .HasColumnType("varchar(45)");

                    b.Property<string>("des_temporada")
                        .HasColumnType("varchar(25)");

                    b.Property<string>("des_titulo")
                        .HasColumnType("varchar(45)");

                    b.Property<int>("idt_autor")
                        .HasColumnType("int");

                    b.Property<int>("idt_categoria")
                        .HasColumnType("int");

                    b.Property<int>("idt_editora")
                        .HasColumnType("int");

                    b.Property<string>("ind_lancamento")
                        .HasColumnType("char(1)");

                    b.Property<int>("num_ano")
                        .HasColumnType("int");

                    b.Property<int>("qtd_livro_estoque")
                        .HasColumnType("int");

                    b.Property<decimal>("val_livro")
                        .HasColumnType("decimal(6, 2)");

                    b.HasKey("idt_livro");

                    b.HasIndex("idt_autor");

                    b.HasIndex("idt_categoria");

                    b.HasIndex("idt_editora");

                    b.ToTable("Livros");
                });

            modelBuilder.Entity("livrariaAPI.Models.Entities.LivroVenda", b =>
                {
                    b.Property<int>("idt_livro_venda")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("idt_livro")
                        .HasColumnType("int");

                    b.Property<int>("idt_venda")
                        .HasColumnType("int");

                    b.Property<int>("qtd_livro")
                        .HasColumnType("int");

                    b.Property<decimal>("val_livro")
                        .HasColumnType("decimal(8, 2)");

                    b.HasKey("idt_livro_venda");

                    b.HasIndex("idt_livro");

                    b.HasIndex("idt_venda");

                    b.ToTable("livro_venda");
                });

            modelBuilder.Entity("livrariaAPI.Models.Entities.Usuario", b =>
                {
                    b.Property<int>("idt_usuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("des_senha")
                        .HasColumnType("char(4)");

                    b.Property<string>("log_usuario")
                        .HasColumnType("char(10)");

                    b.HasKey("idt_usuario");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("livrariaAPI.Models.Entities.Venda", b =>
                {
                    b.Property<int>("idt_venda")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateOnly>("dat_venda")
                        .HasColumnType("date");

                    b.Property<int>("idt_usuario")
                        .HasColumnType("int");

                    b.HasKey("idt_venda");

                    b.HasIndex("idt_usuario");

                    b.ToTable("Vendas");
                });

            modelBuilder.Entity("livrariaAPI.Models.Entities.Livro", b =>
                {
                    b.HasOne("livrariaAPI.Models.Entities.Autor", "Autor")
                        .WithMany()
                        .HasForeignKey("idt_autor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("livrariaAPI.Models.Entities.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("idt_categoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("livrariaAPI.Models.Entities.Editora", "Editora")
                        .WithMany()
                        .HasForeignKey("idt_editora")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Autor");

                    b.Navigation("Categoria");

                    b.Navigation("Editora");
                });

            modelBuilder.Entity("livrariaAPI.Models.Entities.LivroVenda", b =>
                {
                    b.HasOne("livrariaAPI.Models.Entities.Livro", "Livro")
                        .WithMany()
                        .HasForeignKey("idt_livro")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("livrariaAPI.Models.Entities.Venda", "Venda")
                        .WithMany()
                        .HasForeignKey("idt_venda")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Livro");

                    b.Navigation("Venda");
                });

            modelBuilder.Entity("livrariaAPI.Models.Entities.Venda", b =>
                {
                    b.HasOne("livrariaAPI.Models.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("idt_usuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
