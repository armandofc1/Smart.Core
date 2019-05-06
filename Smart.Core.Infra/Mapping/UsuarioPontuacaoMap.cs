using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart.Core.Domain.Entities;

namespace Smart.Core.Infra.Mapping
{
    public class UsuarioPontuacaoMap : IEntityTypeConfiguration<UsuarioPontuacao>
    {
        public void Configure(EntityTypeBuilder<UsuarioPontuacao> builder)
        {

        }
    }
}
