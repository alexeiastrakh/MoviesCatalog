using MoviesCatalog.Models;

namespace MoviesCatalog.Repository.Interfaces
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetAllMovies();
        Task<Movie> GetMovie(int id);
        Task AddMovie(Movie movie);
        void UpdateMovie(Movie movie);
        Task DeleteMovie(int id);
        Task SaveAsync();
    }
}
