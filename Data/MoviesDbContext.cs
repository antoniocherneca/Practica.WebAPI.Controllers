using Microsoft.EntityFrameworkCore;
using Practica.WebAPI.Controllers.Models;
using System.Data;

namespace Practica.WebAPI.Controllers.Data
{
    public class MoviesDbContext : DbContext
    {
        public MoviesDbContext(DbContextOptions<MoviesDbContext> options) : base(options)
        {
            FillMovies();
        }

        public DbSet<Movie> Movies { get; set; }

        private void FillMovies()
        {
            if (Movies.Count() == 0)
            {
                Movies.Add(new Movie { Id = 1, Description = "Oppenheimer", Duration = 181, Gender = "Drama" });
                Movies.Add(new Movie { Id = 2, Description = "Culpa mía", Duration = 117, Gender = "Romance" });
                Movies.Add(new Movie { Id = 3, Description = "Creed III", Duration = 116, Gender = "Acción" });
                SaveChanges();
            }
        }
    }
}
