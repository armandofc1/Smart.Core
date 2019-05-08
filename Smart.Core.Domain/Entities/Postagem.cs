using System;
using System.Collections.Generic;

namespace Smart.Core.Domain.Entities
{
    public class Postagem
    {
        public Postagem()
        {
            PostagemCategorias = new HashSet<PostagemCategoria>();
        }

        public int Codigo { get; set; }
        public int UsuarioCodigo { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Titulo { get; set; }
        public string Subtitulo { get; set; }
        public string Resumo { get; set; }
        public string Conteudo { get; set; }
        public string Foto { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public string Status { get; set; }

        public ICollection<PostagemCategoria> PostagemCategorias { get; set; }

    }
}
