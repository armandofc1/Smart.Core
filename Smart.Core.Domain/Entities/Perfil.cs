using System;
using System.Collections.Generic;

namespace Smart.Core.Domain.Entities
{
    public class Perfil
    {
        public Perfil()
        {
            PerfisUsuario = new HashSet<PerfilUsuario>();
        }

        public int Codigo { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<PerfilUsuario> PerfisUsuario { get; set; }
    }
}
