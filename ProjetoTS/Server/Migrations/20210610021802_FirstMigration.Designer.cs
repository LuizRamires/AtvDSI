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
    [Migration("20210610021802_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ProjetoTS.Shared.Desenvolvedora", b =>
                {
                    b.Property<int>("IdDesenvolvedora")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Endereco")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("IdDesenvolvedora");

                    b.ToTable("Desenvolvedoraes");
                });

            modelBuilder.Entity("ProjetoTS.Shared.DetalheGame", b =>
                {
                    b.Property<int>("IdGame")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("EstadodeConservacao")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("TempoDeUso")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("IdGame");

                    b.ToTable("DetalheGames");
                });

            modelBuilder.Entity("ProjetoTS.Shared.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("DesenvolvedoraIdDesenvolvedora")
                        .HasColumnType("int");

                    b.Property<int>("IdDesenvolvedora")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("Id");

                    b.HasIndex("DesenvolvedoraIdDesenvolvedora");

                    b.ToTable("Games");
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

            modelBuilder.Entity("ProjetoTS.Shared.TagGame", b =>
                {
                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("TagId", "Id");

                    b.HasIndex("Id");

                    b.ToTable("TagGames");
                });

            modelBuilder.Entity("ProjetoTS.Shared.DetalheGame", b =>
                {
                    b.HasOne("ProjetoTS.Shared.Game", "Game")
                        .WithOne("DetalheGame")
                        .HasForeignKey("ProjetoTS.Shared.DetalheGame", "IdGame")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjetoTS.Shared.Game", b =>
                {
                    b.HasOne("ProjetoTS.Shared.Desenvolvedora", "Desenvolvedora")
                        .WithMany("Game")
                        .HasForeignKey("DesenvolvedoraIdDesenvolvedora");
                });

            modelBuilder.Entity("ProjetoTS.Shared.TagGame", b =>
                {
                    b.HasOne("ProjetoTS.Shared.Game", "game")
                        .WithMany("TagGame")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetoTS.Shared.Tag", "tag")
                        .WithMany("TagGame")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}