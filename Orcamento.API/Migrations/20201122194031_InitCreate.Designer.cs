﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Orcamento.API.Context;

namespace Orcamento.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20201122194031_InitCreate")]
    partial class InitCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Orcamento.API.Models.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("varchar(80) CHARACTER SET utf8mb4")
                        .HasMaxLength(80);

                    b.Property<string>("Nome")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("IdCliente");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Orcamento.API.Models.Item", b =>
                {
                    b.Property<int>("Iditem")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(80) CHARACTER SET utf8mb4")
                        .HasMaxLength(80);

                    b.Property<string>("Flag")
                        .IsRequired()
                        .HasColumnType("varchar(300) CHARACTER SET utf8mb4")
                        .HasMaxLength(300);

                    b.Property<decimal>("valoritem")
                        .HasColumnType("decimal(65,30)")
                        .HasMaxLength(2);

                    b.HasKey("Iditem");

                    b.ToTable("items");
                });

            modelBuilder.Entity("Orcamento.API.Models.ListaItem", b =>
                {
                    b.Property<int>("idlistaitem")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("iditem")
                        .HasColumnType("int");

                    b.Property<int>("idorcamento")
                        .HasColumnType("int");

                    b.Property<int?>("itemIditem")
                        .HasColumnType("int");

                    b.Property<int?>("orcamentoidorcamento")
                        .HasColumnType("int");

                    b.Property<decimal>("valor")
                        .HasColumnType("decimal(65,30)")
                        .HasMaxLength(80);

                    b.HasKey("idlistaitem");

                    b.HasIndex("itemIditem");

                    b.HasIndex("orcamentoidorcamento");

                    b.ToTable("listaItems");
                });

            modelBuilder.Entity("Orcamento.API.Models.Tborcamento", b =>
                {
                    b.Property<int>("idorcamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("clienteIdCliente")
                        .HasColumnType("int");

                    b.Property<DateTime>("dt_alteracao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("dt_orcamento")
                        .HasColumnType("datetime(6)")
                        .HasMaxLength(80);

                    b.Property<string>("sit_orcamento")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("usu_alteracao")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("usu_orcamento")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<decimal>("valor_descont")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("valor_total")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("idorcamento");

                    b.HasIndex("clienteIdCliente");

                    b.ToTable("tborcamentos");
                });

            modelBuilder.Entity("Orcamento.API.Models.ListaItem", b =>
                {
                    b.HasOne("Orcamento.API.Models.Item", "item")
                        .WithMany("ListaItens")
                        .HasForeignKey("itemIditem");

                    b.HasOne("Orcamento.API.Models.Tborcamento", "orcamento")
                        .WithMany("ListaItens")
                        .HasForeignKey("orcamentoidorcamento");
                });

            modelBuilder.Entity("Orcamento.API.Models.Tborcamento", b =>
                {
                    b.HasOne("Orcamento.API.Models.Cliente", "cliente")
                        .WithMany("tborcamentos")
                        .HasForeignKey("clienteIdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}