using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smart.Core.Domain.Entities;
using Smart.Core.Infra.Context;
using Newtonsoft.Json.Linq;

namespace Smart.Core.Web.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostagemController : ControllerBase
    {

        private readonly SmartContext _context;

        public PostagemController(SmartContext context)
        {
            _context = context;
        }

        // GET: api/Postagem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Postagem>>> Get()
        {
            return await _context.Postagem.ToListAsync();
        }

        // GET: api/Postagem/5
        [HttpGet("{codigo}")]
        public async Task<ActionResult<Postagem>> Get(int codigo)
        {
            return await _context.Postagem.FirstOrDefaultAsync(c => c.Codigo == codigo);
        }

        // POST: api/Postagem
        [HttpPost]
        public async Task<ActionResult<Categoria>> Post([FromBody] JObject postModel)
        {
            if (postModel == null)
            {
                return BadRequest();
            }

            Postagem model = new Postagem()
            {
                UsuarioCodigo = postModel.GetValue("UsuarioCodigo").Value<int>(),
                DataCriacao = DateTime.Now,
                Titulo = postModel.GetValue("Titulo").Value<string>(),
                Subtitulo = postModel.GetValue("Subtitulo").Value<string>(),
                Resumo = postModel.GetValue("Resumo").Value<string>(),
                Conteudo = postModel.GetValue("Conteudo").Value<string>(),
                DataInicial = new DateTime(2019, 05, 1),
                DataFinal = new DateTime(2019, 12, 31),
                Status = 1
            };

            _context.Postagem.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { codigo = model.Codigo }, model);
        }

        // PUT: api/Postagem/5
        [HttpPut("{codigo}")]
        public async Task<ActionResult<Postagem>> Put(int codigo, [FromBody] JObject postModel)
        {
            if (postModel == null)
            {
                return BadRequest();
            }

            var model = _context.Postagem.FirstOrDefault(c => c.Codigo == codigo);
            if (model != null)
            {
                model.Titulo = postModel.GetValue("Titulo").Value<string>();
                model.Subtitulo = postModel.GetValue("Subtitulo").Value<string>();
                model.Resumo = postModel.GetValue("Resumo").Value<string>();
                model.Conteudo = postModel.GetValue("Conteudo").Value<string>();
            }
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { codigo = model.Codigo }, model);
        }

        // DELETE api/Postagem/5
        [HttpDelete("{codigo}")]
        public void Delete(int codigo)
        {
            var model = _context.Postagem.FirstOrDefault(c => c.Codigo == codigo);
            if (model != null)
            {
                _context.Remove(model);
                _context.SaveChanges();
            }
        }
    }
}
