using System;
using System.Collections.Generic;

namespace Smart.Core.Domain.Entities
{
    public class TipoMovimentacao
    {
        public TipoMovimentacao()
        {
            Movimentacoes = new HashSet<UsuarioMovimentacao>();
        }

        public int Codigo { get; set; }
        public string Tipo { get; set; }

        public virtual ICollection<UsuarioMovimentacao> Movimentacoes { get; set; }
    }
}
