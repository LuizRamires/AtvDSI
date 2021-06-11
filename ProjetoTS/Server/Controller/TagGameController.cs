using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoTS.Shared;
using ProjetoTS.Server;

namespace ProjetoTS.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TagGameController : Controller
    {
        private readonly ApplicationDBContext db;
        public TagGameController(ApplicationDBContext db)//injeção de dependencia
        {
            this.db = db;
        }
    
    [HttpPost]
    [Route("AddTag")]
    public async Task<ActionResult> Post([FromBody] TagGameDTO taggame)
        {
            try
            {
                var newTagGame = new TagGame
                {
                    TagId = Convert.ToInt32(taggame.TagId), //Id da tag
                    Id = Convert.ToInt32(taggame.Id),//Id do game
                    tag = taggame.tag,
                    game = taggame.game
                };
                db.Add(newTagGame);
                await db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return View(e);
            }
        }



        [HttpGet]
        [Route("LTagGame")]
        public async Task<IActionResult> Get() //o tipo de retorno dessa ação
        {
            var tgp = await db.TagGames.ToListAsync();//resulta em uma Lista de Games
            return Ok(tgp);
        }

        /*
        [HttpGet]
        [Route("ListarTagGame")]
        public async Task<TagGame> Get() //o tipo de retorno dessa ação
        {
            Console.WriteLine("Entrou");
            //var games = db.Games.Include(x => x.TagGame).ThenInclude(x => x.tag).ToList();
            var games = db.TagGames.SingleOrDefault();//resulta em uma Lista de Games
            
            return games;
        }
        
       [HttpGet]
       [Route("FiltroLista")]
           public async Task<IActionResult> Get([FromBody] int Id ) //o tipo de retorno dessa ação
           {
               foreach(var item in )
               {

               }

           }

        
        [HttpGet]
        [Route("ListarTagGame")] //pega um game pelo id
        public async Task<ActionResult<TagGame>> Get(int id)
        {
            var game = await db.TagGames.FindAsync(id);
            return Ok(game);
        }
        */

        [HttpGet]
        [Route("IdP")] //pega um game pelo id
        public async Task<Game> Get([FromBody]int id)
        {
            var game = await db.Games.SingleOrDefaultAsync(x => x.Id == id);
            return game;
        }
        /*
        [HttpGet]
        [Route("ITG")] //pega um game pelo id
        public async Task<IActionResult> Get([FromQuery] int id)
        {
            var game = await db.Tags.SingleOrDefaultAsync(x => x.TagId == id);
            return Ok(game);
        }*/
    }
}
