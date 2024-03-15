using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WAD_BACKEND_14669.Models;
using WAD_BACKEND_14669.Repositories;

namespace WAD_BACKEND_14669.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesRepository _moviesRepository;

        public MoviesController(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }

        // GET: api/Movies
        [HttpGet]
        public async Task<IEnumerable<Movie>> GetMovies()
        {
            return await _moviesRepository.GetMovies();
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            var movie = await _moviesRepository.GetMovieById(id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        // PUT: api/Movies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            try
            {
                await _moviesRepository.PutMovie(movie);
            }
            catch (DbUpdateConcurrencyException)
            {
                var movieSingle = await _moviesRepository.GetMovieById(id);
                if (movieSingle == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            await _moviesRepository.PostMovie(movie);

            return CreatedAtAction("GetMovie", new { id = movie.Id }, movie);
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            await _moviesRepository.DeleteMovie(id);

            return NoContent();
        }
    }
}
