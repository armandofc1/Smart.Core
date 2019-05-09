using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart.Core.Domain.Entities;

namespace Smart.Core.Infra.Mapping
{
    public class PerfilMap : IEntityTypeConfiguration<Perfil>
    {
        public void Configure(EntityTypeBuilder<Perfil> builder)
        {
            builder.ToTable("TB_PERFIL");

            builder.HasKey(e => e.Codigo);
            builder.Property(e => e.Codigo).HasColumnName("CD_PERFIL")
                .IsRequired()
                .HasMaxLength(3)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Nome).HasColumnName("NOME")
                .IsRequired()
                .HasMaxLength(30);

            builder.HasIndex(e => e.Nome).HasName("PERF_NOME");
        }
    }
}
