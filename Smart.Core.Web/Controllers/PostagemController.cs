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
                .FirstOrDefaultAsync(m => m.Codigo == codigo);
            if (postagem == null)
            {
                return NotFound();
            }

            return View(postagem);
        }
    }
}