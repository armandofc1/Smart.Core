using System;
using System.Collections.Generic;

namespace Smart.Core.Domain.Entities
{
    public class PostagemCategoria
    {
        public int PostagemCodigo { get; set; }
        public int CategoriaCodigo { get; set; }

        public Postagem Postagens { get; set; }
        public Categoria Categorias { get; set; }
    }
}
