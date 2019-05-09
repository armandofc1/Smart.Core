using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart.Core.Domain.Entities;

namespace Smart.Core.Infra.Mapping
{
    public class PostagemCategoriaMap : IEntityTypeConfiguration<PostagemCategoria>
    {
        public void Configure(EntityTypeBuilder<PostagemCategoria> builder)
        {
            builder.ToTable("TB_POSTAGEM_CATEGORIA");

            builder.HasKey(e => new { e.PostagemCodigo, e.CategoriaCodigo })
                    .ForSqlServerIsClustered(false);

            builder.Property(e => e.PostagemCodigo).HasColumnName("CD_POSTAGEM")
                .IsRequired()
                .HasMaxLength(9);

            builder.Property(e => e.CategoriaCodigo).HasColumnName("CD_CATEGORIA")
                .IsRequired()
                .HasMaxLength(3);

            builder.HasOne(d => d.Postagens)
                .WithMany(p => p.PostagemCategorias)
                .HasForeignKey(d => d.PostagemCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_POSTCATEGORIA_POST");

            builder.HasOne(d => d.Categorias)
                .WithMany(p => p.PostagemCategorias)
                .HasForeignKey(d => d.CategoriaCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_POSTCATEGORIA_CAT");
        }
    }
}
