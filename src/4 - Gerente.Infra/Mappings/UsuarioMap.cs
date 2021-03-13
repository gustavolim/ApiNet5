using Gerente.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gerente.Infra.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.HasKey(x=> x.Id);

            builder.Property(x=> x.Id)
                .UseIdentityColumn()
                .HasColumnType("BIGINT");

            builder.Property(x=> x.Nome)
                .IsRequired()
                .HasMaxLength(80)
                .HasColumnName("nome")
                .HasColumnType("VARCHAR(80)");
            
            builder.Property(x=> x.Email)
                .IsRequired()
                .HasMaxLength(180)
                .HasColumnName("Email")
                .HasColumnType("VARCHAR(180)");

            builder.Property(x=> x.Senha)
            .IsRequired()
            .HasMaxLength(30)
            .HasColumnType("VARCHAR(30)")
            .HasColumnName("senha");
        }
    }
}