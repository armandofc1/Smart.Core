using System;
using System.Collections.Generic;

namespace Smart.Core.Domain.Entities
{
    public class PerfilUsuario
    {
        public int UsuarioCodigo { get; set; }
        public int PerfilCodigo { get; set; }

        public Usuario Usuarios { get; set; }
        public Perfil Perfis { get; set; }
    }
}
