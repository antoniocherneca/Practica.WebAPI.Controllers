using Microsoft.EntityFrameworkCore;
using Practica.WebAPI.Controllers.Models;
using System.Data;

namespace Practica.WebAPI.Controllers.Data
{
    public class VideoDbContext : DbContext
    {
        public VideoDbContext(DbContextOptions<VideoDbContext> options) : base(options)
        {
            FillMovies();
            FillPartners();
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Partner> Partners { get; set; }

        private void FillMovies()
        {
            if (Movies.Count() == 0)
            {
                Movies.Add(new Movie { MovieId = 1, Description = "Oppenheimer", Duration = 181, Gender = "Drama" });
                Movies.Add(new Movie { MovieId = 2, Description = "Culpa mía", Duration = 117, Gender = "Romance" });
                Movies.Add(new Movie { MovieId = 3, Description = "Creed III", Duration = 116, Gender = "Acción" });
                SaveChanges();
            }
        }

        private void FillPartners()
        {
            if (Partners.Count() == 0)
            {
                Partners.Add(new Partner { PartnerId = 1, Name = "Juan", LastName = "Perez", Address = "Jujuy 158" });
                Partners.Add(new Partner { PartnerId = 2, Name = "Jose", LastName = "Montes", Address = "Salta 447" });
                Partners.Add(new Partner { PartnerId = 3, Name = "Manuel", LastName = "Rios", Address = "Montevideo 1159" });
                SaveChanges();
            }
        }
    }
}
