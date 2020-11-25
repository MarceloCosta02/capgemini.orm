using apiorm.Business.Interfaces;
using apiorm.Models;
using apiorm.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiorm.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetController : BaseController
    {
        private readonly IPetBusiness _pet;

        public PetController(IPetBusiness pet)
        {
            _pet = pet;
        }

        // GET: api/pet
        [HttpGet]
        public Task<IActionResult> Get() => VerifyResultAsync(async () =>
        {
             var pets = await _pet.GetAllPets();
             return new ObjectResult(pets) { StatusCode = StatusCodes.Status200OK };
        });
    }
}
