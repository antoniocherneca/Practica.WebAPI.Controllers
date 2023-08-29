using Practica.WebAPI.Controllers.Models;

namespace Practica.WebAPI.Controllers.Data.Interfaces
{
    public interface IPartnerRepository
    {
        IEnumerable<Partner> GetAllPartners();
        Partner GetPartnerById(int id);
        void CreatePartner(Partner partner);
        void UpdatePartner(Partner partner);
        void DeletePartner(int id);
    }
}
