using Microsoft.EntityFrameworkCore;
using Practica.WebAPI.Controllers.Models;

namespace Practica.WebAPI.Controllers.Data
{
    public class PartnersDbContext : DbContext
    {
        public PartnersDbContext(DbContextOptions<PartnersDbContext> options) : base(options)
        {
            FillPartners();
        }

        public DbSet<Partner> Partners { get; set; }

        private void FillPartners()
        {
            if (Partners.Count() == 0)
            {
                Partners.Add(new Partner { Id = 1, Name = "Juan", LastName = "Pérez", Address = "Jujuy 1254" });
                Partners.Add(new Partner { Id = 2, Name = "María", LastName = "López", Address = "Pringles 814" });
                Partners.Add(new Partner { Id = 3, Name = "José", LastName = "Gimenez", Address = "España 447" });
                SaveChanges();
            }
        }
    }
}
