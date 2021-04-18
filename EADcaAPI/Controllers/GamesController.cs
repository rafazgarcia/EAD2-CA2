using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EADcaAPI.Controllers
{
    [Route("api/Games")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        //DB context set up
        private readonly GameContext _dbContext;

        public GamesController(GameContext dbContext)
        {
            _dbContext = dbContext;
        }

        //HTTP GET all games in a list.
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Game>> GetAll()
        {
            var gamesList = _dbContext.Game.ToList();
            return Ok(gamesList);
        }

        //This will return games where the platform is equal to the user input passed from Android app as an arg
        [HttpGet("getGamesByPlatform")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> getGamesByPlatform(string platformIN)
        {

            //.FirstOrDefault (?)
            var gamesList = _dbContext.Game.ToList().Where(g => g.platform == platformIN);
            return Ok(gamesList);

        }

        //This will return games where the genre is equal to the user input passed from Android app as an arg
        [HttpPost("getGamesByGenre")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> getGamesByGenre(string genreIN)
        {

            //.FirstOrDefault (?)
            var gamesList = _dbContext.Game.Where(g => g.genre == genreIN);
            return Ok(gamesList);

        }

        //This POST enters a new game into the DB
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Insert(Game gameToAdd)
        {
            _dbContext.Game.Add(gameToAdd);
            try
            {


                await _dbContext.SaveChangesAsync(); //This is the save statement, commits to db.
                return Ok();
            }

            catch (Exception e)
            {
                return StatusCode(500);
            }

        }
    }
    }
