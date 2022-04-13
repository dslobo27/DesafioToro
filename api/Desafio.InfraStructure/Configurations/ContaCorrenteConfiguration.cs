using Desafio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio.InfraStructure.Configurations
{
    public class ContaCorrenteConfiguration : IEntityTypeConfiguration<ContaCorrente>
    {
        public void Configure(EntityTypeBuilder<ContaCorrente> builder)
        {
            builder.HasKey(map => map.Id);
            builder.Property(map => map.Id);

            builder.Property(map => map.Saldo)
                .HasDefaultValue(0)
                .HasColumnType("decimal(18,2)")
                .IsRequired();
        }
    }
}