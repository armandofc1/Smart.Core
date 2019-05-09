using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart.Core.Domain.Entities;

namespace Smart.Core.Infra.Mapping
{
    public class TipoMovimentacaoMap : IEntityTypeConfiguration<TipoMovimentacao>
    {
        public void Configure(EntityTypeBuilder<TipoMovimentacao> builder)
        {
            builder.ToTable("TB_TIPO_MOVIMENTACAO");

            builder.HasKey(e => e.Codigo);
            builder.Property(e => e.Codigo).HasColumnName("CD_TIPO_MOVIMENTACAO")
                .IsRequired()
                .HasMaxLength(3)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Tipo).HasColumnName("TIPO")
                .IsRequired()
                .HasMaxLength(30);

            builder.HasIndex(e => e.Tipo).HasName("TIPO_MOVIMENT_TIPO");
        }
    }
}
