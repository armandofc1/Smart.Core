﻿using System;
using System.Collections.Generic;

namespace Smart.Core.Domain.Entities
{
    public class Categoria
    {
        public Categoria() {
            PostagemCategorias = new HashSet<PostagemCategoria>();
            UsuarioInteresseCategorias = new HashSet<UsuarioInteresseCategoria>();
        }

        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public ICollection<PostagemCategoria> PostagemCategorias { get; set; }
        public ICollection<UsuarioInteresseCategoria> UsuarioInteresseCategorias { get; set; }
    }
}
