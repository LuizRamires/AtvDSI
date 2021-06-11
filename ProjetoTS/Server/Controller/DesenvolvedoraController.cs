using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoTS.Server;
using ProjetoTS.Shared;

namespace ProjetoTS.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DesenvolvedoraController : Controller
    {
        private readonly ApplicationDBContext db;

        public DesenvolvedoraController(ApplicationDBContext db)//injeção de dependencia
        {
            this.db = db;
        }

        [HttpPost]
        [Route("CDesenvolvedora")]
        public async Task<ActionResult> Post([FromBody] DesenvolvedoraDTO desenvolvedora)//recebe um game do body do Http e não do header
        {
            try
            {
                var newDesenvolvedora = new Desenvolvedora
                {
                    IdDesenvolvedora=Convert.ToInt32(desenvolvedora.IdDesenvolvedora),
                    Nome=desenvolvedora.Nome,
                    Endereco=desenvolvedora.Endereco,
                    Game=desenvolvedora.Game
                };
                db.Add(newDesenvolvedora);
                await db.SaveChangesAsync();//insere na tabela
                return Ok();

            }
            catch (Exception e)
            {
                return View(e);
            }
        }

       
        [HttpGet]
        [Route("ListDesenvolvedoraes")]
        public async Task<IActionResult> Get() //o tipo de retorno dessa ação
        {
            var desenvolvedores = await db.Desenvolvedoraes.ToListAsync();//resulta em uma Lista de Games
            return Ok(desenvolvedores);
        }
        
    }
}
