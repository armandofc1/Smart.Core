using System;
using System.Collections.Generic;

namespace Smart.Core.Domain.Entities
{
    public class UsuarioPontuacao
    {
        public int UsuarioCodigo { get; set; }
        public virtual Usuario Usuario { get; set; }
        public int PontosSaldo { get; set; }
    }
}
