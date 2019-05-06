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
                .ValueGeneratedNever();

            builder.Property(e => e.TipoUsuario.Codigo).HasColumnName("CD_TIPO_USUARIO")
                .IsRequired()
                .HasMaxLength(3);

            builder.Property(e => e.DataCadastro).HasColumnName("DT_CADASTRO")
                .IsRequired()
                .HasColumnType("date");

            builder.Property(e => e.Nome).HasColumnName("NOME");
            builder.HasIndex(e => e.Nome).HasName("NOME");
            builder.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.SobreNome).HasColumnName("SOBRENOME");
            builder.Property(e => e.SobreNome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Nome).HasColumnName("LOGIN");
            builder.HasIndex(e => e.Nome).HasName("LOGIN");
            builder.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(e => e.Sexo).HasColumnName("SEXO");
            builder.Property(e => e.Sexo)
                .IsRequired()
                .HasMaxLength(1);


            CD_USUARIO
CD_TIPO_USUARIO
DT_CADASTRO
NOME
SOBRENOME
SEXO
LOGIN
SENHA
EMAIL
FOTO
STATUS



            builder.HasKey(e => e.OrderId);

                builder.HasIndex(e => e.CustomerId)
                    .HasName("CustomersOrders");

                builder.HasIndex(e => e.EmployeeId)
                    .HasName("EmployeesOrders");

                builder.HasIndex(e => e.OrderDate)
                    .HasName("OrderDate");

                builder.HasIndex(e => e.ShipPostalCode)
                    .HasName("ShipPostalCode");

                builder.HasIndex(e => e.ShipVia)
                    .HasName("ShippersOrders");

                builder.HasIndex(e => e.ShippedDate)
                    .HasName("ShippedDate");

                builder.Property(e => e.OrderId).HasColumnName("OrderID");

                builder.Property(e => e.CustomerId)
                    .HasColumnName("CustomerID")
                    .HasMaxLength(5);

                builder.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                builder.Property(e => e.Freight)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                builder.Property(e => e.OrderDate).HasColumnType("datetime");

                builder.Property(e => e.RequiredDate).HasColumnType("datetime");

                builder.Property(e => e.ShipAddress).HasMaxLength(60);

                builder.Property(e => e.ShipCity).HasMaxLength(15);

                builder.Property(e => e.ShipCountry).HasMaxLength(15);

                builder.Property(e => e.ShipName).HasMaxLength(40);

                builder.Property(e => e.ShipPostalCode).HasMaxLength(10);

                builder.Property(e => e.ShipRegion).HasMaxLength(15);

                builder.Property(e => e.ShippedDate).HasColumnType("datetime");

                builder.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Orders_Customers");

                builder.HasOne(d => d.Employee)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Orders_Employees");

                builder.HasOne(d => d.ShipViaNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ShipVia)
                    .HasConstraintName("FK_Orders_Shippers");
            }
    }
}
