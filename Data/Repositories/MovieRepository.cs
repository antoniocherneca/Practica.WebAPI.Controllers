using Practica.WebAPI.Controllers.Data.Interfaces;
using Practica.WebAPI.Controllers.Models;

namespace Practica.WebAPI.Controllers.Data.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly VideoDbContext _dbContext;

        public MovieRepository(VideoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return _dbContext.Movies.ToList();
        }

        public Movie GetMovieById(int id)
        {
            return _dbContext.Movies.FirstOrDefault(m => m.MovieId == id);
        }

        public void CreateMovie(Movie movie)
        {
            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();
        }

        public void UpdateMovie(Movie movie)
        {
            _dbContext.Movies.Update(movie);
            _dbContext.SaveChanges();
        }

        public void DeleteMovie(int id)
        {
            var movie = _dbContext.Movies.FirstOrDefault(m => m.MovieId == id);
            if (movie != null)
            {
                _dbContext.Movies.Remove(movie);
                _dbContext.SaveChanges();
            }
        }
    }
}
