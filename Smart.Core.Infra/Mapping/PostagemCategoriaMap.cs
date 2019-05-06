using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart.Core.Domain.Entities;

namespace Smart.Core.Infra.Mapping
{
    public class PostagemCategoriaMap : IEntityTypeConfiguration<PostagemCategoria>
    {
        public void Configure(EntityTypeBuilder<PostagemCategoria> builder)
        {

        }
    }
}
