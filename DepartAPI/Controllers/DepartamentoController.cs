using DepartApi.Data;
using DepartApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DepartApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class DepartamentoController : Controller
    {
        private readonly IRepository _repo;

        public DepartamentoController(IRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetAllDepartamentosAsync(true);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }


        }


        [HttpGet("{DepartamentoId}")]
        public async Task<IActionResult> GetByDepartamentoId(int DepartamentoId)
        {
            try
            {
                var result = await _repo.GetDepartamentoAsyncById(DepartamentoId, true);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }


        }


        [HttpPost]
        public async Task<IActionResult> Post(Departamento model)
        {
            try
            {
                _repo.Add(model);

                if (await _repo.SaveChangesAsync())
                {

                    return Ok(model);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }
        [HttpPut("{departamentoId}")]
        public async Task<IActionResult> Put(int departamentoId, Departamento model)
        {
            try
            {
                var departamento = await _repo.GetDepartamentoAsyncById(departamentoId, false);
                if(departamento == null) return NotFound();


                _repo.Update(model);

                if (await _repo.SaveChangesAsync())
                {

                    return Ok(model);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }
        [HttpDelete("{departamentoId}")]
        public async Task<IActionResult> Delete(int departamentoId)
        {
            try
            {
                var departamento = await _repo.GetDepartamentoAsyncById(departamentoId, false);
                if (departamento == null) return NotFound();


                _repo.Delete(departamento);

                if (await _repo.SaveChangesAsync())
                {

                    return Ok("Sucesso");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }
    }
}

