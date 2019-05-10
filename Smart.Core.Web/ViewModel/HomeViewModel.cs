using System.Collections.Generic;
using Smart.Core.Domain.Entities;

namespace Smart.Core.Web.ViewModel
{
    public class HomeViewModel
    {
        public ICollection<Postagem> Postagens { get; set; }
    }
}
