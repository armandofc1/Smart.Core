using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart.Core.Domain.Entities;

namespace Smart.Core.Infra.Mapping
{
    public class UsuarioPontuacaoMap : IEntityTypeConfiguration<UsuarioPontuacao>
    {
        public void Configure(EntityTypeBuilder<UsuarioPontuacao> builder)
        {
            builder.ToTable("TB_USUARIO_PONTUACAO");

            builder.HasKey(e => e.UsuarioCodigo);
            builder.Property(e => e.UsuarioCodigo).HasColumnName("CD_USUARIO")
                .IsRequired()
                .HasMaxLength(9);

            builder.Property(e => e.PontosSaldo).HasColumnName("PONTOS_SALDO")
                .IsRequired()
                .HasMaxLength(9);

            builder.HasIndex(e => e.UsuarioCodigo).HasName("UK_PONTUACAO_USUARIO")
                .IsUnique();

            builder.HasOne(d => d.Usuario)
                .WithMany(p => p.Pontuacao)
                .HasForeignKey(d => d.UsuarioCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PONTUACAO_USUARIO");
        }
    }
}
