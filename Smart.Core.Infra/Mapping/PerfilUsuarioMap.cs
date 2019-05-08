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

            builder.HasKey(e => new { e.PerfilCodigo, e.UsuarioCodigo })
                    .ForSqlServerIsClustered(false);

            builder.Property(e => e.PerfilCodigo).HasColumnName("CD_PERFIL")
                .IsRequired()
                .HasMaxLength(3);

            builder.Property(e => e.UsuarioCodigo).HasColumnName("CD_USUARIO")
                .IsRequired()
                .HasMaxLength(9);

            builder.HasOne(d => d.Usuarios)
                .WithMany(p => p.PerfisUsuario)
                .HasForeignKey(d => d.UsuarioCodigo)
                .HasConstraintName("FK_PERFUSUARIO_USUA");

            builder.HasOne(d => d.Perfis)
                .WithMany(p => p.PerfisUsuario)
                .HasForeignKey(d => d.PerfilCodigo)
                .HasConstraintName("FK_PERFUSUARIO_PERF");
        }
    }
}
