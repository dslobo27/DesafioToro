using Desafio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio.InfraStructure.Configurations
{
    public class AtivoUsuarioConfiguration : IEntityTypeConfiguration<AtivoUsuario>
    {
        public void Configure(EntityTypeBuilder<AtivoUsuario> builder)
        {
            builder.HasKey(map => map.Id);
            builder.Property(map => map.Id);

            builder.Property(map => map.AtivoId)
                .IsRequired();

            builder.Property(map => map.UsuarioId)
                .IsRequired();

            builder.Property(map => map.Quantidade)
                .HasDefaultValue(0)
                .IsRequired();
        }
    }
}