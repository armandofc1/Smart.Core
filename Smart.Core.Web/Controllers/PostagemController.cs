using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Smart.Core.Domain.Entities;
using Smart.Core.Infra.Context;
using Smart.Core.Web.Models;
using Smart.Core.Web.ViewModel.PostagemViewModel;
using System.Diagnostics;

namespace Smart.Core.Web.Controllers
{
    public class PostagemController : Controller
    {
        private readonly SmartContext _context;

        public PostagemController(SmartContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? codigo)
        {
            if (codigo == null)
            {
                return NotFound();
            }

            var postagem = await _context.Postagem
                .Include(post => post.Usuario)
                .Include(post => post.Comentarios)
                    .ThenInclude(comentario => comentario.Usuario)
                .Include(post => post.PostagemCategorias)
                    .ThenInclude(post_categoria => post_categoria.Categorias)
                .Include(post => post.Movimentacoes)              
                .FirstOrDefaultAsync(post => post.Codigo == codigo);
            if (postagem == null)
            {
                return NotFound();
            }

            var model = new DetailViewModel
            {
                Postagem = postagem
            };
            return View(model);
        }
    }
}