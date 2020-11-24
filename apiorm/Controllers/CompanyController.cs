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
    public class CompanyController : ControllerBase
    {
        private readonly IPetShopRepository _repo;

        public CompanyController(IPetShopRepository repo)
        {
            _repo = repo;
        }

        // GET: api/Company
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var companys = await _repo.GetAllCompanys();

                return Ok(companys);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }         
    }
}
