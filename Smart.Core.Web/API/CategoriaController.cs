using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smart.Core.Domain.Entities;
using Smart.Core.Infra.Context;
using Smart.Core.Web.Models;

namespace Smart.Core.Web.API
{
    [Route("api/categoria")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly SmartContext _context;

        public CategoriaController(SmartContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> Get()
        {
            return await _context.Categoria.ToListAsync();
        }

        // GET api/values/5
        [HttpGet("{codigo}")]
        public async Task<ActionResult<Categoria>> Get(int codigo)
        {
            return await _context.Categoria.FirstOrDefaultAsync(c => c.Codigo == codigo);
        }

        // POST: api/Todo
        //[HttpPost, Route("api/categoria/Adicionar")]
        //public async Task<ActionResult<Categoria>> Adicionar([FromBody] string nome, string descricao)
        //{
        //    var categoria = new Categoria()
        //    {
        //        Nome = nome,
        //        Descricao = descricao
        //    };

        //    _context.Categoria.Add(categoria);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction(nameof(Get), new { codigo = categoria.Codigo }, categoria);
        //}


        // BODY: Customer(JSON, XML)
        [HttpPost, Route("api/categoria/Adicionar")]
        public async Task<IActionResult> Adicionar([FromBody] Categoria categoria)
        {
            if (categoria == null)
            {
                return BadRequest();
            }
            _context.Categoria.Add(categoria);
            var added  = await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { codigo = added }, categoria);
        }

        //// POST: api/Todo
        //[HttpPost,Route("api/categoria/Adicionar")]
        //public async Task<ActionResult<Categoria>> Adicionar([FromBody] Categoria item)
        //{
        //    _context.Categoria.Add(item);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction(nameof(Get), new { codigo = item.Codigo }, item);
        //}

        // POST api/values
        //[HttpPost]
        //public IActionResult Post1([FromBody] CategoriaInputModel inputModel)
        //{
        //    if (inputModel == null)
        //    {
        //        return BadRequest("Employee is null.");
        //    }

        //    var categoria = new Categoria()
        //    {
        //        Nome = inputModel.Nome,
        //        Descricao = inputModel.Descricao
        //    };
        //    _context.Categoria.Add(categoria);
        //    _context.SaveChangesAsync();

        //    return CreatedAtRoute(
        //          "Get",
        //          new { Codigo = inputModel.Codigo },
        //          inputModel);

        //}

        // PUT api/values/5
        [HttpPut("{codigo}")]
        public void Put(int codigo, [FromBody] CategoriaInputModel model)
        {
            var categoria =  _context.Categoria.FirstOrDefault(c => c.Codigo == codigo);
            if(categoria != null)
            {
                categoria.Nome = model.Nome;
                categoria.Descricao = model.Descricao;
            }
            _context.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
