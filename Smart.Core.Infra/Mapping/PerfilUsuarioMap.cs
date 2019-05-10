using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart.Core.Domain.Entities;

namespace Smart.Core.Infra.Mapping
{
    public class PerfilUsuarioMap : IEntityTypeConfiguration<PerfilUsuario>
    {
        public void Configure(EntityTypeBuilder<PerfilUsuario> builder)
        {
            builder.ToTable("TB_PERFIL_USUARIO");

            builder.HasKey(e => new { e.PerfilCodigo, e.UsuarioCodigo });

            builder.Property(e => e.PerfilCodigo).HasColumnName("CD_PERFIL")
                .IsRequired()
                .HasMaxLength(3);

            builder.Property(e => e.UsuarioCodigo).HasColumnName("CD_USUARIO")
                .IsRequired()
                .HasMaxLength(9);

            builder.Property(e => e.GerenciarUsuarios).HasColumnName("GERENCIAR_USUARIOS")
                .IsRequired()
                .HasMaxLength(1);

            builder.Property(e => e.GerenciarCategorias).HasColumnName("GERENCIAR_CATEGORIAS")
                .IsRequired()
                .HasMaxLength(1);

            builder.Property(e => e.GerenciarPostagens).HasColumnName("GERENCIAR_POSTAGENS")
                .IsRequired()
                .HasMaxLength(1);

            builder.Property(e => e.GerenciarComentarios).HasColumnName("GERENCIAR_COMENTARIOS")
                .IsRequired()
                .HasMaxLength(1);

            builder.HasOne(d => d.Usuario)
                .WithMany(p => p.PerfisUsuario)
                .HasForeignKey(d => d.UsuarioCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PERFUSUARIO_USUA");

            builder.HasOne(d => d.Perfil)
                .WithMany(p => p.PerfisUsuario)
                .HasForeignKey(d => d.PerfilCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PERFUSUARIO_PERF");
        }
    }
}
