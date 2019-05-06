using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart.Core.Domain.Entities;

namespace Smart.Core.Infra.Mapping
{
    public class UsuarioMovimentacaoMap : IEntityTypeConfiguration<UsuarioMovimentacao>
    {
        public void Configure(EntityTypeBuilder<UsuarioMovimentacao> builder)
        {

        }
    }
}
