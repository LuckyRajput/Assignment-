using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.Services.Interfaces;
using Movies.Services.Models;

namespace Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        [HttpGet("GetAllMovies")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_movieService.GetAllMovies());
            }
            catch (Exception ex)
            {
               return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] MoviCommandModel moviCommandModel)
        {
            try
            {
                return Ok(_movieService.CreateMovie(moviCommandModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] MoviCommandModel moviCommandModel)
        {
            try
            {
                return Ok(_movieService.UpdateMovie(moviCommandModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
