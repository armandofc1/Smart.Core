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

namespace Smart.Core.Web.Components
{
    public class Menu : ViewComponent
    {
        private readonly SmartContext _context;

        public Menu(SmartContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
