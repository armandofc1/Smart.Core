using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart.Core.Domain.Entities;

namespace Smart.Core.Infra.Mapping
{
    public class TipoUsuarioMap : IEntityTypeConfiguration<TipoUsuario>
    {
        public void Configure(EntityTypeBuilder<TipoUsuario> builder)
        {
            builder.ToTable("TB_TIPO_USUARIO");

            builder.HasKey(e => e.Codigo);
            builder.Property(e => e.Codigo).HasColumnName("CD_TIPO_USUARIO")
                .HasMaxLength(3)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Tipo).HasColumnName("TIPO")
                .IsRequired()
                .HasMaxLength(30);

            builder.HasIndex(e => e.Tipo).HasName("TIPO_USUA_TIPO");
        }
    }
}
