using Microsoft.AspNetCore.Mvc;

namespace DepartApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FuncionarioController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("ola");
        }

    }
}
