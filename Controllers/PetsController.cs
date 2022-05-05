using System.Net.NetworkInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetsController(ApplicationContext context) {
            _context = context;
        }

        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        [HttpGet]
        public IEnumerable<Pet> GetPets() {
            return _context.Pets

            .Include(Pet => Pet.ownedBy);
        }

        [HttpPost]

        public Pet Post(Pet pet) {
            _context.Add(pet);
            _context.SaveChanges();

            return pet;
            
            // .Include(Pet => Pet.ownedBy);
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id) {
            var petToRemove = _context.Pets.FirstOrDefault(pet => pet.id ==id);
            if (petToRemove != null) {
                _context.Pets.Remove(petToRemove);
                _context.SaveChanges();
            }
            return NoContent();
        }

        [HttpPut("{id}/checkin")]
        public Pet Put(int id)
        {

            var pet = _context.Pets.SingleOrDefault(pet => pet.id == id);
            pet.checkedInAt = DateTime.Now;


            _context.Pets.Update(pet);
            _context.SaveChanges();

            return pet;

        }

        [HttpPut("{id}/checkout")]
        public Pet Update(int id)
        {

            var pet = _context.Pets.SingleOrDefault(pet => pet.id == id);
            pet.checkedInAt = null;

            _context.Pets.Update(pet);
            _context.SaveChanges();

            return pet;

        }




        // [HttpGet]
        // [Route("test")]
        // public IEnumerable<Pet> GetPets() {
        //     PetOwner blaine = new PetOwner{
        //         name = "Blaine"
        //     };

        //     Pet newPet1 = new Pet {
        //         name = "Big Dog",
        //         petOwner = blaine,
        //         color = PetColorType.Black,
        //         breed = PetBreedType.Poodle,
        //     };

        //     Pet newPet2 = new Pet {
        //         name = "Little Dog",
        //         petOwner = blaine,
        //         color = PetColorType.Golden,
        //         breed = PetBreedType.Labrador,
        //     };

        //     return new List<Pet>{ newPet1, newPet2};
        // }
    }
}
