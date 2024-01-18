using DepartApi.Data;
using DepartApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DepartApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FuncionariosController : Controller
    {
        private readonly IRepository _repo;

        public FuncionariosController(IRepository repo)
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
        public async Task<IActionResult> Post(Funcionarios model)
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
        public async Task<IActionResult> Put(int funcionarioId, Funcionarios model)
        {
            try
            {
                var funcionario = await _repo.GetFuncionarioAsyncById(funcionarioId, true);

                if (funcionario == null)
                    return NotFound();


                funcionario.Nome = model.Nome;
                funcionario.Foto = model.Foto;
                funcionario.RG = model.RG;
                funcionario.DepartamentoId = model.DepartamentoId;

                _repo.Update(funcionario);


                if (await _repo.SaveChangesAsync())
                {
                    return Ok(funcionario);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }




        [HttpDelete("{FuncionarioId}")]
        public async Task<IActionResult> Delete(int funcionarioId)
        {
            try
            {
                var funcionario = await _repo.GetFuncionarioAsyncById(funcionarioId, false);
                if (funcionario == null) return NotFound();

                _repo.Delete(funcionario);

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
