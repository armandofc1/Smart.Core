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
            builder.Property(e => e.Codigo).HasColumnName("CD_CATEGORIA");
           //builder.Property(e => e.Codigo).HasColumnType("INT");

            builder.Property(e => e.Nome).HasColumnName("NOME");
            builder.HasIndex(e => e.Nome).HasName("NOME");
            builder.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(e => e.Descricao).HasColumnName("DESCRICAO");
            builder.Property(e => e.Descricao)
            .HasMaxLength(200);

        }
    }
}
