using System;
using System.Collections.Generic;

namespace Smart.Core.Domain.Entities
{
    public class Usuario
    {
        public Usuario(){
            Postagens = new HashSet<Postagem>();
            PerfisUsuario = new HashSet<PerfilUsuario>();
            Comentarios = new HashSet<Comentario>();
            MovimentacoesOrigem = new HashSet<UsuarioMovimentacao>();
            MovimentacoesDestino = new HashSet<UsuarioMovimentacao>();
            UsuarioInteresseCategorias = new HashSet<UsuarioInteresseCategoria>();
            Pontuacao = new HashSet<UsuarioPontuacao>();
        }

        public int Codigo { get; set; }
        public int TipoUsuarioCodigo { get; set; }
        public virtual TipoUsuario TipoUsuario { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Sexo { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public string Foto { get; set; }
        public int Status { get; set; }

        public virtual ICollection<Postagem> Postagens { get; set; }
        public virtual ICollection<PerfilUsuario> PerfisUsuario { get; set; }
        public virtual ICollection<Comentario> Comentarios { get; set; }
        public virtual ICollection<UsuarioMovimentacao> MovimentacoesOrigem { get; set; }
        public virtual ICollection<UsuarioMovimentacao> MovimentacoesDestino { get; set; }
        public virtual ICollection<UsuarioInteresseCategoria> UsuarioInteresseCategorias { get; set; }
        public virtual ICollection<UsuarioPontuacao> Pontuacao { get; set; }

    }
}
