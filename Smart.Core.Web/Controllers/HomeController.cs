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
using Smart.Core.Web.ViewModel.HomeViewModel;
using System.Diagnostics;

namespace Smart.Core.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly SmartContext _context;

        public HomeController(SmartContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var postagens = await _context.Postagem.ToListAsync();
            var model = new DetailViewModel {
                Postagens = postagens
            };
            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
