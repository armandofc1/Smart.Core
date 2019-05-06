using System;
using System.Collections.Generic;

namespace Smart.Core.Domain.Entities
{
    public class Categoria
    {
        public Categoria() { }

        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
