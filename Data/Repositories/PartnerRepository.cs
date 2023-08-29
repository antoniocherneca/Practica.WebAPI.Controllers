using Practica.WebAPI.Controllers.Data.Interfaces;
using Practica.WebAPI.Controllers.Models;

namespace Practica.WebAPI.Controllers.Data.Repositories
{
    public class PartnerRepository : IPartnerRepository
    {
        private readonly PartnersDbContext _dbContext;

        public PartnerRepository(PartnersDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Partner> GetAllPartners()
        {
            return _dbContext.Partners.ToList();
        }

        public Partner GetPartnerById(int id)
        {
            return _dbContext.Partners.FirstOrDefault(p => p.Id == id);
        }

        public void CreatePartner(Partner partner)
        {
            _dbContext.Partners.Add(partner);
            _dbContext.SaveChanges();
        }

        public void UpdatePartner(Partner partner)
        {
            _dbContext.Partners.Update(partner);
            _dbContext.SaveChanges();
        }

        public void DeletePartner(int id)
        {
            var partner = _dbContext.Partners.FirstOrDefault(p => p.Id == id);
            if (partner != null)
            {
                _dbContext.Remove(partner);
                _dbContext.SaveChanges();
            }
        }
    }
}
