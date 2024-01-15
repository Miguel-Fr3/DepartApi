using DepartApi.Data;
using DepartApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DepartApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FuncionarioController : Controller
    {
        private readonly IRepository _repo;

        public FuncionarioController(IRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetAllFuncionariosAsync(true);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }


        }

        [HttpGet("{FuncionarioId}")]
        public async Task<IActionResult> GetByFuncionarioId(int FuncionarioId)
        {
            try
            {
                var result = await _repo.GetFuncionarioAsyncById(FuncionarioId, true);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }


        }


        [HttpPost]
        public async Task<IActionResult> Post(Funcionario model)
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
        [HttpPut("{FuncionarioId}")]
        public async Task<IActionResult> Put(int FuncionarioId, Funcionario model)
        {
            try
            {
                var funcionario = await _repo.GetFuncionarioAsyncById(FuncionarioId, false);
                if (funcionario == null) return NotFound();


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
        [HttpDelete("{FuncionarioId}")]
        public async Task<IActionResult> Delete(int FuncionarioId)
        {
            try
            {
                var funcionario = await _repo.GetFuncionarioAsyncById(FuncionarioId, false);
                if (funcionario == null) return NotFound();


                _repo.Delete(funcionario);

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

