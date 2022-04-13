﻿// <auto-generated />
using System;
using Desafio.InfraStructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Desafio.InfraStructure.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                            Id = new Guid("f167a925-df66-443e-a3d7-40091a991b31"),
                            Codigo = "PETR4",
                            QuantidadeNegociados = 5,
                            Valor = 28.44m
                        },
                        new
                        {
                            Id = new Guid("7438311b-37ca-488e-bbf9-bb7af8a670ab"),
                            Codigo = "MGLU3",
                            QuantidadeNegociados = 4,
                            Valor = 25.91m
                        },
                        new
                        {
                            Id = new Guid("be6fa5e2-3a2d-4685-9586-253f1ef7e31f"),
                            Codigo = "VVAR3",
                            QuantidadeNegociados = 3,
                            Valor = 25.91m
                        },
                        new
                        {
                            Id = new Guid("ab5c2ecc-e451-4687-97d7-e5f5463b7d09"),
                            Codigo = "SANB11",
                            QuantidadeNegociados = 2,
                            Valor = 40.77m
                        },
                        new
                        {
                            Id = new Guid("5c3ee54f-1b6a-4e49-a2b6-fbca14ae1794"),
                            Codigo = "TORO4",
                            QuantidadeNegociados = 1,
                            Valor = 115.98m
                        });
                });

            modelBuilder.Entity("Desafio.Domain.Entities.AtivoUsuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AtivoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantidade")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AtivoId");

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

                    b.HasKey("Id");

                    b.HasIndex("ContaCorrenteId");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4d88d723-7565-4de8-adf8-7d5f43aff5e0"),
                            CPF = "17811768097",
                            ContaCorrenteId = new Guid("ca6331b4-52d4-4ee7-9970-7be33fa76628"),
                            Nome = "Cesar Tralli"
                        });
                });

            modelBuilder.Entity("Desafio.Domain.Entities.AtivoUsuario", b =>
                {
                    b.HasOne("Desafio.Domain.Entities.Ativo", "Ativo")
                        .WithMany()
                        .HasForeignKey("AtivoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Desafio.Domain.Entities.Usuario", "Usuario")
                        .WithMany()
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
#pragma warning restore 612, 618
        }
    }
}
