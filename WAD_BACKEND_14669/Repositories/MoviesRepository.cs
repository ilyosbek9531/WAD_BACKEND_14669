using Microsoft.EntityFrameworkCore;
using WAD_BACKEND_14669.Data;
using WAD_BACKEND_14669.Models;

namespace WAD_BACKEND_14669.Repositories
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly MovieDbContext _dbContext;

        public MoviesRepository(MovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task DeleteMovie(int id)
        {
            var movie = await _dbContext.Movies.FirstOrDefaultAsync(m => m.Id == id);

            if(movie != null) 
            {
                _dbContext.Movies.Remove(movie);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Movie> GetMovieById(int id)
        {
            return await _dbContext.Movies.Include(m => m.Category).FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Movie>> GetMovies()
        {
            return await _dbContext.Movies.Include(m => m.Category).ToListAsync();
        }

        public async Task PostMovie(Movie movie)
        {
            await _dbContext.Movies.AddAsync(movie);
            await _dbContext.SaveChangesAsync();
        }

        public async Task PutMovie(Movie movie)
        {
            _dbContext.Entry(movie).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
