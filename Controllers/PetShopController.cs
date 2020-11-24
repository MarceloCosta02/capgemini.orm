using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace apiorm.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetShopController : ControllerBase
    {               

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
