using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica.WebAPI.Controllers.Data;
using Practica.WebAPI.Controllers.Data.Interfaces;
using Practica.WebAPI.Controllers.Data.Repositories;
using Practica.WebAPI.Controllers.Models;

namespace Practica.WebAPI.Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartnersController : ControllerBase
    {
        private readonly IPartnerRepository _partnerRepository;

        public PartnersController(IPartnerRepository partnerRepository)
        {
            _partnerRepository = partnerRepository;
        }

        [HttpGet]
        public IActionResult GetAllPartners()
        {
            var movies = _partnerRepository.GetAllPartners();
            if (movies != null)
            {
                return Ok(movies);
            }
            return NotFound("No se encontraron socios");
        }

        [HttpGet("{id}")]
        public IActionResult GetPartner(int id)
        {
            var partner = PartnerExists(id);
            if (partner != null)
            {
                return Ok(partner);
            }
            return NotFound("No se encuentra el socio");
        }

        [HttpPost]
        public IActionResult PostPartner(Partner partner)
        {
            _partnerRepository.CreatePartner(partner);
            return CreatedAtAction(nameof(GetPartner), new { id = partner.Id }, partner);
        }

        [HttpPut("{id}")]
        public IActionResult PutPartner(Partner updatedPartner, int id)
        {
            var partner = PartnerExists(id);
            if (partner != null)
            {
                partner.Name = updatedPartner.Name;
                partner.LastName = updatedPartner.LastName;
                partner.Address = updatedPartner.Address;
                _partnerRepository.UpdatePartner(partner);
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePartner(int id)
        {
            var partner = PartnerExists(id);
            if (partner != null)
            {
                _partnerRepository.DeletePartner(id);
                return NoContent();
            }
            return NotFound();
        }

        private Partner PartnerExists(int id)
        {
            var partner = _partnerRepository.GetPartnerById(id);
            return partner;
        }
    }
}
