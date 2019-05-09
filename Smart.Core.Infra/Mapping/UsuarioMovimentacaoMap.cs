using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart.Core.Domain.Entities;

namespace Smart.Core.Infra.Mapping
{
    public class UsuarioMovimentacaoMap : IEntityTypeConfiguration<UsuarioMovimentacao>
    {
        public void Configure(EntityTypeBuilder<UsuarioMovimentacao> builder)
        {
            builder.ToTable("TB_USUARIO_MOVIMENTACAO");

            builder.HasKey(e => e.Codigo);
            builder.Property(e => e.Codigo).HasColumnName("CD_MOVIMENTACAO")
                .IsRequired()
                .HasMaxLength(9)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.TipoMovimentacaoCodigo).HasColumnName("CD_TIPO_MOVIMENTACAO")
                .IsRequired()
                .HasMaxLength(3);

            builder.Property(e => e.DataCadastro).HasColumnName("DT_CADASTRO")
                .IsRequired()
                .HasColumnType("datetime")
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("getdate()");

            builder.Property(e => e.UsuarioOrigemCodigo).HasColumnName("CD_USUARIO_ORIGEM")
                .IsRequired()
                .HasMaxLength(9);

            builder.Property(e => e.UsuarioDestinoCodigo).HasColumnName("CD_USUARIO_DESTINO")
                .IsRequired()
                .HasMaxLength(9);

            builder.Property(e => e.PostagemCodigo).HasColumnName("CD_POSTAGEM")
                .IsRequired()
                .HasMaxLength(9);

            builder.Property(e => e.Pontos).HasColumnName("PONTOS")
                .IsRequired()
                .HasMaxLength(9);

            builder.HasIndex(e => e.PostagemCodigo).HasName("MOV_POST");
            builder.HasIndex(e => new { e.PostagemCodigo, e.UsuarioOrigemCodigo }).HasName("MOV_POST_USUA_ORIGEM");
            builder.HasIndex(e => new { e.PostagemCodigo, e.UsuarioDestinoCodigo }).HasName("MOV_POST_USUA_DESTINO");
            builder.HasIndex(e => new { e.UsuarioOrigemCodigo, e.TipoMovimentacaoCodigo }).HasName("MOV_POST_USUA_ORIGEM_TIPO");
            builder.HasIndex(e => new { e.UsuarioDestinoCodigo, e.TipoMovimentacaoCodigo }).HasName("MOV_POST_USUA_DESTINO_TIPO");

            builder.HasOne(d => d.TipoMovimentacao)
                .WithMany(p => p.Movimentacoes)
                .HasForeignKey(d => d.TipoMovimentacaoCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MOV_TIPO");

            builder.HasOne(d => d.UsuarioOrigem)
                .WithMany(p => p.MovimentacoesOrigem)
                .HasForeignKey(d => d.UsuarioOrigemCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MOV_USU_ORIGEM");

            builder.HasOne(d => d.UsuarioDestino)
                .WithMany(p => p.MovimentacoesDestino)
                .HasForeignKey(d => d.UsuarioDestinoCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MOV_USU_DETINO");

            builder.HasOne(d => d.Postagem)
                .WithMany(p => p.Movimentacoes)
                .HasForeignKey(d => d.PostagemCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MOV_POSTAGEM");
        }
    }
}
