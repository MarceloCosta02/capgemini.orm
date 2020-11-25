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
    public class ClientController : BaseController
    {
        private readonly IRepositoryEF _repo;
        private readonly IClientBusiness _client;

        public ClientController(IRepositoryEF repo, IClientBusiness client)
        {
            _repo = repo;
            _client = client;
        }

        // GET: api/client
        [HttpGet]
        public Task<IActionResult> Get() => VerifyResultAsync(async () =>
        {
            var clients = await _client.GetAllClients();
            return new ObjectResult(clients) { StatusCode = StatusCodes.Status200OK };
        });


        // POST: api/Client
        [HttpPost]
        public Task<IActionResult> Post(Client model) => VerifyResultAsync(async () =>
        {      
            await _client.CreateClient(model);
            return new ObjectResult("Cliente criado com sucesso!") { StatusCode = StatusCodes.Status201Created };
        });  
    }
}
