using Desafio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio.InfraStructure.Configurations
{
    public class AtivoUsuarioConfiguration : IEntityTypeConfiguration<AtivoUsuario>
    {
        public void Configure(EntityTypeBuilder<AtivoUsuario> builder)
        {
            builder.HasKey(map => new { map.AtivoId, map.UsuarioId });

            builder.Property(map => map.AtivoId)
                .IsRequired();

            builder.Property(map => map.UsuarioId)
                .IsRequired();

            builder.Property(map => map.Quantidade)
                .HasDefaultValue(0)
                .IsRequired();

            builder.HasOne(map => map.Ativo)
                .WithMany(map => map.AtivosUsuario)
                .HasForeignKey(map => map.AtivoId);

            builder.HasOne(map => map.Usuario)
                .WithMany(map => map.AtivosUsuario)
                .HasForeignKey(map => map.UsuarioId);
        }
    }
}