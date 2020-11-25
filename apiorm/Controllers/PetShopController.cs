using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiorm.Business.Interfaces;
using apiorm.Models;
using apiorm.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace apiorm.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetShopController : BaseController
    {
        private readonly IRepositoryEF _repo;
        private readonly IPetShopBusiness _petShop;

        public PetShopController(IRepositoryEF repo, IPetShopBusiness petShop)
        {
            _petShop = petShop;
            _repo = repo;
        }

        // GET: api/PetShop
        [HttpGet]
        public Task<IActionResult> Get() => VerifyResultAsync(async () =>
        {
            var petShops = await _petShop.GetAllPetShops();
            return new ObjectResult(petShops) { StatusCode = StatusCodes.Status200OK };
        });

        // GET: api/PetShop/get-by-id?id=1
        [HttpGet("{id}")]
        public Task<IActionResult> GetById(int id) => VerifyResultAsync(async () =>
        {
            var petShops = await _petShop.GetPetShopById(id);
            return new ObjectResult(petShops) { StatusCode = StatusCodes.Status200OK };
        });

        // GET: api/PetShop/name/Pluto
        [HttpGet("name/{name}")]
        public Task<IActionResult> GetByName(string name) => VerifyResultAsync(async () =>
        {
            var petShops = await _petShop.GetPetShopByName(name);
            return new ObjectResult(petShops) { StatusCode = StatusCodes.Status200OK };
        });

        // POST: api/PetShop
        [HttpPost]
        public Task<IActionResult> Post([FromBody] PetShop model) => VerifyResultAsync(async () =>
        {
            await _petShop.CreatePetShop(model);
            return new ObjectResult("PetShop criado com sucesso!") { StatusCode = StatusCodes.Status201Created };
        });

        // PUT: api/PetShop/update/5
        [HttpPut("update/{id}")]
        public Task<IActionResult> Put([FromBody] PetShop model, int id) => VerifyResultAsync(async () =>
        {
            var petShop = await _petShop.UpdatePetShop(model, id);
            return new ObjectResult(petShop) { StatusCode = StatusCodes.Status200OK };
        });       

        // DELETE: api/PetShop/5
        [HttpDelete("{id}")]
        public Task<IActionResult> Delete(int id) => VerifyResultAsync(async () =>
        {
            await _petShop.DeletePetShop(id);
            return NoContent();
        });
    }
}
