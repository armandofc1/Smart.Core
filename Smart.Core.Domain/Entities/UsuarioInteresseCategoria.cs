using System;
using System.Collections.Generic;

namespace Smart.Core.Domain.Entities
{
    public class UsuarioInteresseCategoria
    {
        public int UsuarioCodigo { get; set; }
        public virtual Usuario Usuario { get; set; }
        public int CategoriaCodigo { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
