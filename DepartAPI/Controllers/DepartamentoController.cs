using DepartApi.Data;
using DepartApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DepartApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class DepartamentosController : Controller
    {
        private readonly IRepository _repo;

        public DepartamentosController(IRepository repo)
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
        [HttpGet("{DepartamentoId}/Funcionarios")]
        public async Task<IActionResult> GetFuncionariosByDepartamentoId(int DepartamentoId)
        {
            try
            {
                var funcionarios = await _repo.GetFuncionariosByDepartamentoIdAsync(DepartamentoId);

                return Ok(funcionarios);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post(Departamentos model)
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
        [HttpPut("{DepartamentoId}")]
        public async Task<IActionResult> Put(int departamentoId, Departamentos model)
        {
            try
            {
                var departamento = await _repo.GetDepartamentoAsyncById(departamentoId, false);
                if (departamento == null) return NotFound();


                departamento.Nome = model.Nome;
                departamento.Sigla = model.Sigla;


                _repo.Update(departamento);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok(departamento);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }



        [HttpDelete("{DepartamentoId}")]
        public async Task<IActionResult> Delete(int departamentoId)
        {
            try
            {
                var departamento = await _repo.GetDepartamentoAsyncById(departamentoId, false);
                if (departamento == null) return NotFound();


                _repo.Delete(departamento);

                if (await _repo.SaveChangesAsync())
                {

                    return Ok(new { message = "Sucesso" });
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

