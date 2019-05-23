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


        // POST api/Categoria
        /// <summary>
        /// Cria uma categoria
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     POST api/Categoria
        ///     {
        ///        "nome": "Nome Categoria",
        ///        "descricao": "Descrição Categoria"
        ///     }
        ///
        /// </remarks>
        /// <param name="value"></param>
        /// <returns>Um novo item criado</returns>
        /// <response code="201">Retorna o novo item criado</response>
        /// <response code="400">Se o item não for criado</response> 
        [HttpPost]
        public async Task<ActionResult<Categoria>> Post([FromBody] JObject postModel)
        {
            if (postModel == null)
            {
                return BadRequest();
            }

            Categoria model = new Categoria()
            {
                Nome = postModel.GetValue("Nome").Value<string>(),
                Descricao = postModel.GetValue("Descricao").Value<string>()
            };

            _context.Categoria.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { codigo = model.Codigo }, model);
        }

        // PUT: api/Categoria/5
        [HttpPut("{codigo}")]
        public async Task<ActionResult<Categoria>> Put(int codigo, JObject postModel)
        {
            if (postModel == null)
            {
                return BadRequest();
            }

            var model =  _context.Categoria.FirstOrDefault(c => c.Codigo == codigo);
            if(model != null)
            {
                model.Nome = postModel.GetValue("Nome").Value<string>();
                model.Descricao = postModel.GetValue("Descricao").Value<string>();
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
