using System;
using System.Collections.Generic;

namespace Smart.Core.Domain.Entities
{
    public class Usuario
    {
        public Usuario(){
            Postagens = new HashSet<Postagem>();
            PerfisUsuario = new HashSet<PerfilUsuario>();
        }

        public int Codigo { get; set; }
        public int TipoUsuarioCodigo { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Sexo { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public string Foto { get; set; }
        public int Status { get; set; }

        public ICollection<Postagem> Postagens { get; set; }
        public ICollection<PerfilUsuario> PerfisUsuario { get; set; }
        
    }
}
