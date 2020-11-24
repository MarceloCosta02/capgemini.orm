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
    public class ClientController : ControllerBase
    {
        private readonly IPetShopRepository _repo;

        public ClientController(IPetShopRepository repo)
        {
            _repo = repo;
        }

        // GET: api/Client
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var clients = await _repo.GetAllClients();

                return Ok(clients);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }


        // POST: api/Client
        [HttpPost]
        public async Task<IActionResult> Post(Client model)
        {
            try
            {
                _repo.Add(model);

                if (await _repo.SaveChangeAsync())
                {
                    return Ok("Cliente criado com sucesso!");
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
