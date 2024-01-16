using Microsoft.EntityFrameworkCore;
using DepartApi.Models;
using System.Linq;
using System.Threading.Tasks;

namespace DepartApi.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
        public async Task<Departamento[]> GetAllDepartamentosAsync(bool includeFuncionarios = false)
        {
            IQueryable<Departamento> query = _context.Departamentos;

            if (includeFuncionarios)
            {
                query = query.Include(d => d.Funcionarios);
            }

            query = query.AsNoTracking()
                         .OrderBy(d => d.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Departamento> GetDepartamentoAsyncById(int departamentoId, bool includeFuncionarios = false)
        {
            IQueryable<Departamento> query = _context.Departamentos;

            if (includeFuncionarios)
            {
                query = query.Include(d => d.Funcionarios);
            }

            query = query.AsNoTracking()
                         .OrderBy(d => d.Id)
                         .Where(d => d.Id == departamentoId);

            return await query.FirstOrDefaultAsync();
        }
        public async Task<Funcionario[]> GetAllFuncionariosAsync(bool includeDepartamento = false)
        {
            IQueryable<Funcionario> query = _context.Funcionarios;

            query = query.AsNoTracking()
                         .OrderBy(f => f.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Funcionario> GetFuncionarioAsyncById(int funcionarioId, bool includeDepartamento = false)
        {
            IQueryable<Funcionario> query = _context.Funcionarios;

            query = query.AsNoTracking()
                         .OrderBy(f => f.Id)
                         .Where(f => f.Id == funcionarioId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Funcionario[]> GetFuncionariosByDepartamentoIdAsync(int departamentoId)
        {
            IQueryable<Funcionario> query = _context.Funcionarios;

            query = query.AsNoTracking()
                         .OrderBy(f => f.Id)
                         .Where(f => f.DepartamentoId == departamentoId);

            return await query.ToArrayAsync();
        }
    }
}