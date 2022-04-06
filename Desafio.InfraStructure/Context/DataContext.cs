using Desafio.Domain.Entities;
using Desafio.InfraStructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;

namespace Desafio.InfraStructure.Context
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AtivoConfiguration());
            modelBuilder.ApplyConfiguration(new ContaCorrenteConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());

            modelBuilder.Entity<Ativo>().HasData(
                new Ativo
                {
                    Id = Guid.NewGuid(),
                    Codigo = "PETR4",
                    QuantidadeNegociados = 5,
                    Valor = 28.44M
                },
                new Ativo
                {
                    Id = Guid.NewGuid(),
                    Codigo = "MGLU3",
                    QuantidadeNegociados = 4,
                    Valor = 25.91M
                },
                new Ativo
                {
                    Id = Guid.NewGuid(),
                    Codigo = "VVAR3",
                    QuantidadeNegociados = 3,
                    Valor = 25.91M
                },
                new Ativo
                {
                    Id = Guid.NewGuid(),
                    Codigo = "SANB11",
                    QuantidadeNegociados = 2,
                    Valor = 40.77M
                },
                new Ativo
                {
                    Id = Guid.NewGuid(),
                    Codigo = "TORO4",
                    QuantidadeNegociados = 1,
                    Valor = 115.98M
                }
             );
        }

        public DbSet<Ativo> Ativos { get; set; }
        public DbSet<ContaCorrente> ContasCorrentes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}