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
    public class CompanyController : BaseController
    {
        private readonly ICompanyBusiness _company;

        public CompanyController(ICompanyBusiness company)
        {
            _company = company;
        }

        // GET: api/company
        [HttpGet]
        public Task<IActionResult> Get() => VerifyResultAsync(async () =>
        {
            var companys = await _company.GetAllCompanys();
            return new ObjectResult(companys) { StatusCode = StatusCodes.Status200OK };
        });               
    }
}
