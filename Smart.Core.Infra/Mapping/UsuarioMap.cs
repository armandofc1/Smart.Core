using System;
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
                .IsRequired()
                .HasMaxLength(9)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.TipoUsuarioCodigo).HasColumnName("CD_TIPO_USUARIO")
                .IsRequired()
                .HasMaxLength(3);

            builder.Property(e => e.DataCadastro).HasColumnName("DT_CADASTRO")
                .IsRequired()
                .HasDefaultValue(DateTime.Now);

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
                .HasMaxLength(1)
                .HasDefaultValue(1);

            builder.HasIndex(e => e.Nome).HasName("USU_NOME");
            builder.HasIndex(e => e.Login).HasName("USU_LOGIN");
            builder.HasIndex(e => e.TipoUsuarioCodigo).HasName("USU_TIPOUSUARIO");
            builder.HasIndex(e => new { e.Nome, e.Login }).HasName("USU_NOME_LOGIN");

            builder.HasOne(d => d.TipoUsuario)
                .WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.TipoUsuarioCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_USUARIO_TIPO");

            /*
            builder.Property(e => e.Freight)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");
                    .ValueGeneratedOnAdd()
                    .HasDefaultValueSql("getdate()");
                    .UseSqlServerIdentityColumn()
                     builder.HasKey(e => new { e.OrderId, e.ProductId });

            builder.HasKey(e => new { e.PerfilCodigo, e.UsuarioCodigo })
                    .ForSqlServerIsClustered(false);

 */


        }
    }
}
