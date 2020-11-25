using apiorm.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiorm.Controllers
{
    public class BaseController : ControllerBase
    {       
        protected async Task<IActionResult> VerifyResultAsync(Func<Task<IActionResult>> servico)
        {
            try
            {
                return await servico();
            }

            catch (InvalidOperationException inv)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, inv.Message);
            }
            catch (DataNotFoundException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
            catch (ModelFieldIsNullException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
