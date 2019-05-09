using System;
using System.Collections.Generic;

namespace Smart.Core.Domain.Entities
{
    public class PerfilUsuario
    {
        public int UsuarioCodigo { get; set; }
        public virtual Usuario Usuario { get; set; }
        public int PerfilCodigo { get; set; }
        public virtual Perfil Perfil { get; set; }
        public int GerenciarUsuarios { get; set; }
        public int GerenciarCategorias { get; set; }
        public int GerenciarPostagens { get; set; }
        public int GerenciarComentarios { get; set; }
    }
}
