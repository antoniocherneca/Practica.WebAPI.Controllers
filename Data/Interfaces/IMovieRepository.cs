using Practica.WebAPI.Controllers.Models;

namespace Practica.WebAPI.Controllers.Data.Interfaces
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAllMovies();
        Movie GetMovieById(int id);
        void CreateMovie(Movie movie);
        void UpdateMovie(Movie movie);
        void DeleteMovie(int id);
    }
}
