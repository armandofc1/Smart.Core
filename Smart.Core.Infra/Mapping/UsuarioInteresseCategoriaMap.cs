using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart.Core.Domain.Entities;

namespace Smart.Core.Infra.Mapping
{
    public class UsuarioInteresseCategoriaMap : IEntityTypeConfiguration<UsuarioInteresseCategoria>
    {
        public void Configure(EntityTypeBuilder<UsuarioInteresseCategoria> builder)
        {

        }
    }
}
