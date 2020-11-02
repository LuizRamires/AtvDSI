﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoTS.Server;

namespace ProjetoTS.Server.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20201029211804_ummuitos")]
    partial class ummuitos
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ProjetoTS.Shared.DetalheProduto", b =>
                {
                    b.Property<int>("IdProduto")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("EstadodeConservacao")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("TempoDeUso")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("IdProduto");

                    b.ToTable("DetalheProdutos");
                });

            modelBuilder.Entity("ProjetoTS.Shared.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdVendedor")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(5,2)");

                    b.Property<int?>("VendedorIdVendedor")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VendedorIdVendedor");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("ProjetoTS.Shared.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("TagId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("ProjetoTS.Shared.TagProduto", b =>
                {
                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("TagId", "Id");

                    b.HasIndex("Id");

                    b.ToTable("TagProdutos");
                });

            modelBuilder.Entity("ProjetoTS.Shared.Vendedor", b =>
                {
                    b.Property<int>("IdVendedor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Endereco")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("IdVendedor");

                    b.ToTable("Vendedores");
                });

            modelBuilder.Entity("ProjetoTS.Shared.DetalheProduto", b =>
                {
                    b.HasOne("ProjetoTS.Shared.Produto", "Produto")
                        .WithOne("DetalheProduto")
                        .HasForeignKey("ProjetoTS.Shared.DetalheProduto", "IdProduto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjetoTS.Shared.Produto", b =>
                {
                    b.HasOne("ProjetoTS.Shared.Vendedor", "Vendedor")
                        .WithMany("Produto")
                        .HasForeignKey("VendedorIdVendedor");
                });

            modelBuilder.Entity("ProjetoTS.Shared.TagProduto", b =>
                {
                    b.HasOne("ProjetoTS.Shared.Produto", "produto")
                        .WithMany("TagProduto")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetoTS.Shared.Tag", "tag")
                        .WithMany("TagProduto")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}