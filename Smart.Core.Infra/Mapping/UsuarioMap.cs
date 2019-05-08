using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart.Core.Domain.Entities;

namespace Smart.Core.Infra.Mapping
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {

            builder.ToTable("TB_USUARIO");

            builder.HasKey(e => e.Codigo);
            builder.Property(e => e.Codigo).HasColumnName("CD_USUARIO")
                .HasMaxLength(9)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.TipoUsuarioCodigo).HasColumnName("CD_TIPO_USUARIO")
                .IsRequired()
                .HasMaxLength(3);

            builder.Property(e => e.DataCadastro).HasColumnName("DT_CADASTRO")
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(e => e.Nome).HasColumnName("NOME")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.SobreNome).HasColumnName("SOBRENOME")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Sexo).HasColumnName("SEXO")
                .IsRequired()
                .HasMaxLength(1);

            builder.Property(e => e.Login).HasColumnName("LOGIN")
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(e => e.Senha).HasColumnName("SENHA")
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(e => e.Email).HasColumnName("EMAIL")
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.Foto).HasColumnName("FOTO")
            .HasMaxLength(255);

            builder.Property(e => e.Status).HasColumnName("STATUS")
            .IsRequired()
            .HasMaxLength(1);

            builder.HasIndex(e => e.Nome).HasName("NOME");
            builder.HasIndex(e => e.Login).HasName("LOGIN");
            builder.HasIndex(e => e.TipoUsuarioCodigo).HasName("TIPOUSUARIO");

            builder.HasOne(d => d.TipoUsuario)
                .WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.TipoUsuarioCodigo)
                .HasConstraintName("FK_USUARIO_TIPO");

            /*
            builder.Property(e => e.Freight)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                     builder.HasKey(e => new { e.OrderId, e.ProductId });
 */


        }
    }
}
