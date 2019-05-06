using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart.Core.Domain.Entities;

namespace Smart.Core.Infra.Mapping
{
    public class TipoMovimentacaoMap : IEntityTypeConfiguration<TipoMovimentacao>
    {
        public void Configure(EntityTypeBuilder<TipoMovimentacao> builder)
        {

        }
    }
}
