using System;
using System.Collections.Generic;

namespace Smart.Core.Domain.Entities
{
    public class PostagemCategoria
    {
        public int PostagemCodigo { get; set; }
        public virtual Postagem Postagens { get; set; }
        public int CategoriaCodigo { get; set; }
        public virtual Categoria Categorias { get; set; }
    }
}
