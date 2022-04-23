﻿// <auto-generated />
using System;
using Desafio.InfraStructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Desafio.InfraStructure.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220423130703_Desafio")]
    partial class Desafio
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Desafio.Domain.Entities.Ativo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<int>("QuantidadeNegociados")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<decimal>("Valor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18,2)")
                        .HasDefaultValue(0m);

                    b.HasKey("Id");

                    b.ToTable("Ativos");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b0875733-f461-4bc8-bb63-6c9b2534701c"),
                            Codigo = "PETR4",
                            QuantidadeNegociados = 5,
                            Valor = 28.44m
                        },
                        new
                        {
                            Id = new Guid("e622f460-451c-42f1-b64b-5fd5a3dda041"),
                            Codigo = "MGLU3",
                            QuantidadeNegociados = 4,
                            Valor = 25.91m
                        },
                        new
                        {
                            Id = new Guid("76014abf-585a-46f6-b95e-4ff597cd9111"),
                            Codigo = "VVAR3",
                            QuantidadeNegociados = 3,
                            Valor = 25.91m
                        },
                        new
                        {
                            Id = new Guid("6a0064d9-5b8e-4d28-97d5-b3d161e9924a"),
                            Codigo = "SANB11",
                            QuantidadeNegociados = 2,
                            Valor = 40.77m
                        },
                        new
                        {
                            Id = new Guid("9f5f5ebb-8916-4846-b180-fe57a6332a16"),
                            Codigo = "TORO4",
                            QuantidadeNegociados = 1,
                            Valor = 115.98m
                        });
                });

            modelBuilder.Entity("Desafio.Domain.Entities.AtivoUsuario", b =>
                {
                    b.Property<Guid>("AtivoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantidade")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("AtivoId", "UsuarioId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("AtivosUsuario");
                });

            modelBuilder.Entity("Desafio.Domain.Entities.ContaCorrente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Saldo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18,2)")
                        .HasDefaultValue(0m);

                    b.HasKey("Id");

                    b.ToTable("ContasCorrentes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ca6331b4-52d4-4ee7-9970-7be33fa76628"),
                            Saldo = 100m
                        });
                });

            modelBuilder.Entity("Desafio.Domain.Entities.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<Guid>("ContaCorrenteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("ContaCorrenteId");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            Id = new Guid("76c88a58-b592-42fa-8c02-f24a1f47dc35"),
                            CPF = "17811768097",
                            ContaCorrenteId = new Guid("ca6331b4-52d4-4ee7-9970-7be33fa76628"),
                            Nome = "Cesar Tralli",
                            Senha = "123"
                        });
                });

            modelBuilder.Entity("Desafio.Domain.Entities.AtivoUsuario", b =>
                {
                    b.HasOne("Desafio.Domain.Entities.Ativo", "Ativo")
                        .WithMany("AtivosUsuario")
                        .HasForeignKey("AtivoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Desafio.Domain.Entities.Usuario", "Usuario")
                        .WithMany("AtivosUsuario")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ativo");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Desafio.Domain.Entities.Usuario", b =>
                {
                    b.HasOne("Desafio.Domain.Entities.ContaCorrente", "ContaCorrente")
                        .WithMany()
                        .HasForeignKey("ContaCorrenteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContaCorrente");
                });

            modelBuilder.Entity("Desafio.Domain.Entities.Ativo", b =>
                {
                    b.Navigation("AtivosUsuario");
                });

            modelBuilder.Entity("Desafio.Domain.Entities.Usuario", b =>
                {
                    b.Navigation("AtivosUsuario");
                });
#pragma warning restore 612, 618
        }
    }
}