using System;
using System.Collections.Generic;

namespace Smart.Core.Domain.Entities
{
    public class UsuarioMovimentacao
    {
        public int Codigo { get; set; }
        public int TipoMovimentacaoCodigo { get; set; }
        public virtual TipoMovimentacao TipoMovimentacao { get; set; }
        public DateTime DataCadastro { get; set; }
        public int UsuarioOrigemCodigo { get; set; }
        public virtual Usuario UsuarioOrigem { get; set; }
        public int UsuarioDestinoCodigo { get; set; }
        public virtual Usuario UsuarioDestino { get; set; }
        public int PostagemCodigo { get; set; }
        public virtual Postagem Postagem { get; set; }
        public int Pontos { get; set; }
    }
}
