using Microsoft.AspNetCore.Mvc;

namespace DepartApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartamentoController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok("Hello");
            }
            catch (Exception ex) {
                return BadRequest($"oh no: {ex.Message}");
            }

            
        }

    }
}
