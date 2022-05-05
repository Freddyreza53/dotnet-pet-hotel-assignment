using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetOwnersController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetOwnersController(ApplicationContext context) {
            _context = context;
        }

        // private static List<PetOwner> PetOwnersList = new List<PetOwner>();
        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        // [HttpGet]
        // public IEnumerable<PetOwner> GetPets() {
        //     return new List<PetOwner>();
        // }

        [HttpGet]
        public IEnumerable<PetOwner> GetAllOwners() {
            return _context.PetOwners;
        }

        [HttpPost]
        public PetOwner Post(PetOwner petOwner) {
            _context.Add(petOwner);
            _context.SaveChanges();
            return petOwner;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            var petOwnerToRemove = _context.PetOwners.FirstOrDefault(petOwner => petOwner.id == id );
            if (petOwnerToRemove != null) {
                _context.PetOwners.Remove(petOwnerToRemove);
                _context.SaveChanges();
            }
            return NoContent();
        }


        
    }
}
