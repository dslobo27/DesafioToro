using Desafio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio.InfraStructure.Configurations
{
    public class AtivoConfiguration : IEntityTypeConfiguration<Ativo>
    {
        public void Configure(EntityTypeBuilder<Ativo> builder)
        {
            builder.HasKey(map => map.Id);
            builder.Property(map => map.Id);

            builder.Property(map => map.Codigo)
                .HasColumnType("varchar")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(map => map.Valor)
                .HasDefaultValue(0)
                .HasColumnType("decimal(18,2)")
                .IsRequired();
        }
    }
}