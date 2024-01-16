using DepartApi.Models;
using System.Threading.Tasks;

namespace DepartApi.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        Task<Departamento[]> GetAllDepartamentosAsync(bool includeFuncionarios);
        Task<Departamento> GetDepartamentoAsyncById(int departamentoId, bool includeFuncionarios);

        Task<Funcionario[]> GetAllFuncionariosAsync(bool includeDepartamento);
        Task<Funcionario> GetFuncionarioAsyncById(int funcionarioId, bool includeDepartamento);

        Task<Funcionario[]> GetFuncionariosByDepartamentoIdAsync(int departamentoId);
    }
}
