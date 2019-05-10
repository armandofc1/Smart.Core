using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart.Core.Domain.Entities;

namespace Smart.Core.Infra.Mapping
{
    public class PostagemMap : IEntityTypeConfiguration<Postagem>
    {
        public void Configure(EntityTypeBuilder<Postagem> builder)
        {
            builder.ToTable("TB_POSTAGEM");

            builder.HasKey(e => e.Codigo);
            builder.Property(e => e.Codigo).HasColumnName("CD_POSTAGEM")
                .IsRequired()
                .HasMaxLength(9)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.UsuarioCodigo).HasColumnName("CD_USUARIO")
                .IsRequired()
                .HasMaxLength(9);

            builder.Property(e => e.DataCriacao).HasColumnName("DT_CRIACAO")
                .IsRequired()
                .HasDefaultValue(DateTime.Now);

            builder.Property(e => e.Titulo).HasColumnName("TITULO")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Subtitulo).HasColumnName("SUBTITULO")
                .HasMaxLength(150);

            builder.Property(e => e.Resumo).HasColumnName("RESUMO")
                .HasMaxLength(255);

            builder.Property(e => e.Conteudo).HasColumnName("CONTEUDO")
                .HasMaxLength(4000);

            builder.Property(e => e.Foto).HasColumnName("FOTO")
                .HasMaxLength(255);

            builder.Property(e => e.DataInicial).HasColumnName("DT_INICIAL");

            builder.Property(e => e.DataFinal).HasColumnName("DT_FINAL");

            builder.Property(e => e.Status).HasColumnName("STATUS")
                .IsRequired()
                .HasMaxLength(1)
                .HasDefaultValue(1);

            builder.HasIndex(e => e.Titulo).HasName("POST_TITULO");
            builder.HasIndex(e => new { e.Codigo, e.UsuarioCodigo }).HasName("POST_USUARIO");

            builder.HasOne(d => d.Usuario)
                .WithMany(p => p.Postagens)
                .HasForeignKey(d => d.UsuarioCodigo)
                .HasConstraintName("FK_POST_USUARIO");
        }
    }
}
