using System.Collections.Generic;
using Smart.Core.Domain.Entities;

namespace Smart.Core.Web.ViewModel.HomeViewModel
{
    public class DetailViewModel
    {
        public ICollection<Postagem> Postagens { get; set; }
    }
}
