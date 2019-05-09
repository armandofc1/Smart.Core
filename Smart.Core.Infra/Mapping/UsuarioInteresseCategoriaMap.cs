using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart.Core.Domain.Entities;

namespace Smart.Core.Infra.Mapping
{
    public class UsuarioInteresseCategoriaMap : IEntityTypeConfiguration<UsuarioInteresseCategoria>
    {
        public void Configure(EntityTypeBuilder<UsuarioInteresseCategoria> builder)
        {
            builder.ToTable("TB_USUARIO_INTERESSE_CATEGORIA");

            builder.HasKey(e => new { e.UsuarioCodigo, e.CategoriaCodigo })
                    .ForSqlServerIsClustered(false);

            builder.Property(e => e.UsuarioCodigo).HasColumnName("CD_USUARIO")
                .IsRequired()
                .HasMaxLength(9);

            builder.Property(e => e.CategoriaCodigo).HasColumnName("CD_CATEGORIA")
                .IsRequired()
                .HasMaxLength(3);

            builder.HasOne(d => d.Usuario)
                .WithMany(p => p.UsuarioInteresseCategorias)
                .HasForeignKey(d => d.UsuarioCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_INTERESSE_USUARIO");

            builder.HasOne(d => d.Categoria)
                .WithMany(p => p.UsuarioInteresseCategorias)
                .HasForeignKey(d => d.CategoriaCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_INTERESSE_CATEGORIA");
        }
    }
}
