using System;
using System.Collections.Generic;

namespace Smart.Core.Domain.Entities
{
    public class Comentario
    {
        public int Codigo { get; set; }
        public int UsuarioCodigo { get; set; }
        public virtual Usuario Usuario  { get; set; }
        public int PostagemCodigo { get; set; }
        public virtual Postagem Postagem { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Conteudo { get; set; }
        public int Status { get; set; }

    }
}
