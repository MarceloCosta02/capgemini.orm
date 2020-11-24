using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiorm.Models;
using apiorm.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace apiorm.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetShopController : ControllerBase
    {
        private readonly IPetShopRepository _repo;

        public PetShopController(IPetShopRepository repo)
        {
            _repo = repo;
        }

        // GET: api/PetShop
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var petShops = await _repo.GetAllPetShops();

                return Ok(petShops);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // GET: api/PetShop/get-by-id?id=1
        [HttpGet("{get-by-id}")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            try
            {
                var petShops = await _repo.GetPetShopById(id);

                return Ok(petShops);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // GET: api/PetShop/get-by-id?id=1
        [HttpGet("{get-by-name}")]
        public async Task<IActionResult> GetByName([FromQuery] string name)
        {
            try
            {
                var petShops = await _repo.GetPetShopByName(name);

                return Ok(petShops);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // POST: api/PetShop
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PetShop model)
        {
            try
            {
                _repo.Add(model);

                if (await _repo.SaveChangeAsync())
                {
                    return Ok("PetShop criado com sucesso!");
                }

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

            return BadRequest("Não Salvou");
        }

        // PUT: api/PetShop
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] PetShop model, int id)
        {
            try
            {
                var petShop = await _repo.GetPetShopById(id);

                if(petShop == null)
                {
                    return NotFound();
                }
                else
                {
                    _repo.Update(model);

                    if(await _repo.SaveChangeAsync())
                    {
                        return Ok("PetShop atualizado com sucesso");
                    }

                }          

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

            return BadRequest($"Não salvou");
        }

        // DELETE: api/PetShop/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var petShop = await _repo.GetPetShopById(id);

                if (petShop == null)
                {
                    return NotFound();
                }
                else
                {
                    _repo.Delete(petShop);

                    if (await _repo.SaveChangeAsync())
                    {
                        return NoContent();
                    }
                }      
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

            return BadRequest("Não Salvou");
        }
    }
}
