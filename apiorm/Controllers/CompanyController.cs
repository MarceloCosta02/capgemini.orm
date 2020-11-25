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
        private readonly ICompanyRepository _company;

        public CompanyController(ICompanyRepository company)
        {
            _company = company;
        }

        // GET: api/Company
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var companys = await _company.GetAllCompanys();

                return Ok(companys);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }         
    }
}
