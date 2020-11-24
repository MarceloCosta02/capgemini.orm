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
        private readonly IPetShopRepository _repo;

        public PetController(IPetShopRepository repo)
        {
            _repo = repo;
        }

        // GET: api/Pet
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var clients = await _repo.GetAllPets();

                return Ok(clients);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }        
    }
}
