using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart.Core.Domain.Entities;

namespace Smart.Core.Infra.Mapping
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("TB_CATEGORIA");

            builder.HasKey(e => e.Codigo);
            builder.Property(e => e.Codigo).HasColumnName("CD_CATEGORIA")
                .IsRequired()
                .HasMaxLength(3)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Nome).HasColumnName("NOME")
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(e => e.Descricao).HasColumnName("DESCRICAO")
                .HasMaxLength(200);

            builder.HasIndex(e => e.Nome).HasName("CATG_NOME");

        }

    }
}
