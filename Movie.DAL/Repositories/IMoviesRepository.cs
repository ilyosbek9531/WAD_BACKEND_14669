using WAD_BACKEND_14669.Models;

namespace WAD_BACKEND_14669.Repositories
{
    public interface IMoviesRepository
    {
        Task<IEnumerable<Movie>> GetMovies();
        Task<Movie> GetMovieById(int id);
        Task PostMovie(Movie movie);
        Task PutMovie(Movie movie);
        Task DeleteMovie(int id);
    }
}
