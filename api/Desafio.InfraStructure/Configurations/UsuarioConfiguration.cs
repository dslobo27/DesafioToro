using Desafio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio.InfraStructure.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(map => map.Id);
            builder.Property(map => map.Id);

            builder.Property(map => map.ContaCorrenteId)
                .IsRequired();

            builder.Property(map => map.Nome)
                .HasColumnType("varchar")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(map => map.CPF)
                .HasColumnType("varchar")
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(map => map.Senha)
                .HasColumnType("varchar")
                .HasMaxLength(255)
                .IsRequired();
        }
    }
}