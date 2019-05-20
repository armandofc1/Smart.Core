using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smart.Core.Domain.Entities;
using Smart.Core.Infra.Context;
using Newtonsoft.Json;

namespace Smart.Core.Web.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly SmartContext _context;

        public CategoriaController(SmartContext context)
        {
            _context = context;
        }

        // GET: api/Categoria
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> Get()
        {
            return await _context.Categoria.ToListAsync();
        }

        // GET: api/Categoria/5
        [HttpGet("{codigo}")]
        public async Task<ActionResult<Categoria>> Get(int codigo)
        {
            return await _context.Categoria.FirstOrDefaultAsync(c => c.Codigo == codigo);
        }

        // POST: api/Categoria
        [HttpPost]
        public async Task<ActionResult<Categoria>> Post([FromBody] string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return BadRequest();
            }

            Categoria postModel = JsonConvert.DeserializeObject<Categoria>(value);
            Categoria model = new Categoria()
            {
                Nome = postModel.Nome,
                Descricao = postModel.Descricao
            };

            _context.Categoria.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { codigo = model.Codigo }, model);
        }

        // PUT: api/Categoria/5
        [HttpPut("{codigo}")]
        public async Task<ActionResult<Categoria>> Put(int codigo, [FromBody] string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return BadRequest();
            }

            Categoria postModel = JsonConvert.DeserializeObject<Categoria>(value);

            var model =  _context.Categoria.FirstOrDefault(c => c.Codigo == codigo);
            if(model != null)
            {
                model.Nome = postModel.Nome;
                model.Descricao = postModel.Descricao;
            }
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { codigo = model.Codigo }, model);
        }

        // DELETE api/Categoria/5
        [HttpDelete("{codigo}")]
        public void Delete(int codigo)
        {
            var model = _context.Categoria.FirstOrDefault(c => c.Codigo == codigo);
            if (model != null)
            {
                _context.Remove(model);
                _context.SaveChanges();
            }
        }
    }
}
