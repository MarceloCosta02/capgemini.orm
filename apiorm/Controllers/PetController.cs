using apiorm.Models;
using apiorm.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiorm.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetController : ControllerBase
    {
        private readonly IPetRepository _pet;

        public PetController(IPetRepository pet)
        {
            _pet = pet;
        }

        // GET: api/Pet
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var clients = await _pet.GetAllPets();

                return Ok(clients);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }        
    }
}
