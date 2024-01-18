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

        Task<Departamentos[]> GetAllDepartamentosAsync(bool includeFuncionarios);
        Task<Departamentos> GetDepartamentoAsyncById(int departamentoId, bool includeFuncionarios);

        Task<Funcionarios[]> GetAllFuncionariosAsync(bool includeDepartamento);
        Task<Funcionarios> GetFuncionarioAsyncById(int funcionarioId, bool includeDepartamento);

        Task<Funcionarios[]> GetFuncionariosByDepartamentoIdAsync(int departamentoId);
    }
}
