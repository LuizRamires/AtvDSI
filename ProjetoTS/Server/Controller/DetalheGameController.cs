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
    public class DetalheGameController : Controller
    {
        private readonly ApplicationDBContext db;

        public DetalheGameController(ApplicationDBContext db)//injeção de dependencia
        {
            this.db = db;
        }

        [HttpPost]
        [Route("CDetalhe")]
        public async Task<ActionResult> Post([FromBody] DetalheGame detalheGame)//recebe um produto do body do Http e não do header
        {

            try
            {

                var newDGame = new DetalheGame
                {
                    IdGame=detalheGame.IdGame,
                    Descricao = detalheGame.Descricao,
                    TempoDeUso = detalheGame.TempoDeUso,
                    EstadodeConservacao = detalheGame.EstadodeConservacao


                };
                db.Add(newDGame);
                await db.SaveChangesAsync();//insere na tabela
                return Ok();

            }
            catch (Exception e)
            {
                return View(e);
            }
        }

        [HttpGet]
        [Route("Detalhes")] //pega o detalhe do produto
        public async Task<DetalheGame> Get([FromQuery] string id)
        {

            var deta = await db.DetalheGames.SingleOrDefaultAsync(x => x.IdGame == Convert.ToInt32(id));
            return deta;
        }
    }
}
