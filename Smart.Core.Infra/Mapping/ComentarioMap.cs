using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart.Core.Domain.Entities;

namespace Smart.Core.Infra.Mapping
{
    public class ComentarioMap : IEntityTypeConfiguration<Comentario>
    {
        public void Configure(EntityTypeBuilder<Comentario> builder)
        {
            builder.ToTable("TB_COMENTARIO");

            builder.HasKey(e => e.Codigo);
            builder.Property(e => e.Codigo).HasColumnName("CD_COMENTARIO")
                .IsRequired()
                .HasMaxLength(9)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.UsuarioCodigo).HasColumnName("CD_USUARIO")
                .IsRequired()
                .HasMaxLength(9);

            builder.Property(e => e.PostagemCodigo).HasColumnName("CD_POSTAGEM")
                .IsRequired()
                .HasMaxLength(9);

            builder.Property(e => e.DataCriacao).HasColumnName("DT_CRIACAO")
                .IsRequired()
                .HasDefaultValue(DateTime.Now);

            builder.Property(e => e.Conteudo).HasColumnName("CONTEUDO")
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(e => e.Status).HasColumnName("STATUS")
                .IsRequired()
                .HasMaxLength(1)
                .HasDefaultValue(1);

            builder.HasIndex(e => e.PostagemCodigo).HasName("COMENT_POST_CODIGO");
            builder.HasIndex(e => new { e.PostagemCodigo, e.UsuarioCodigo } ).HasName("COMENT_POST_USU");

            builder.HasOne(d => d.Usuario)
                .WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.UsuarioCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_COMENTARIO_USUA");

            builder.HasOne(d => d.Postagem)
                .WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.PostagemCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_COMENTARIO_POST");
        }
    }
}
