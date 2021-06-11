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
    public class GameController : Controller
    {
        private readonly ApplicationDBContext db;

        public GameController(ApplicationDBContext db)//injeção de dependencia
        {
            this.db = db;
        }

        [HttpPost]
        [Route("Criar")]
        public async Task<ActionResult> Post([FromBody] GameDTO game)//recebe um game do body do Http e não do header
        {
            
            try
            {

                var newGame = new Game
                {

                    Id = game.Id,
                    Nome = game.Nome,
                    Preco = game.Preco,
                    TagGame = game.TagGame,
                    DetalheGame=game.DetalheGame,
                    Desenvolvedora=game.Desenvolvedora,
                    IdDesenvolvedora = Convert.ToInt32(game.IdDesenvolvedora)
                  
                };
                db.Add(newGame);
                await db.SaveChangesAsync();//insere na tabela
                return Ok();

            }
            catch (Exception e)
            {
                return View(e);
            }
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<IActionResult> Get() //o tipo de retorno dessa ação
        {
            var games = await db.Games.ToListAsync();//resulta em uma Lista de Games
            return Ok(games);
        }

        [HttpGet]
        [Route("PegaId")] //pega um game pelo id
        public async Task<Game> Get([FromQuery] string id)
        {
            var game = await db.Games.SingleOrDefaultAsync(x => x.Id == Convert.ToInt32(id));
            return game;
        }

        [HttpPut]
        [Route("Atualizar")]
        public async Task<IActionResult> Put([FromBody] Game game) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Entry(game).State = EntityState.Modified;
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw (ex);
            }
            return NoContent();
        }

        [HttpDelete]
        [Route("Deletar/{id}")]
        public async Task<ActionResult<Game>> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var game = await db.Games.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            db.Games.Remove(game);
            await db.SaveChangesAsync();
            return Ok(game);
        }
    }
}
