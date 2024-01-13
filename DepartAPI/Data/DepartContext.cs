using DepartAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace DepartAPI.Data
{
    public class DepartContext(DbContextOptions<DepartContext> options) : DbContext(options)
    {
        public DbSet<Departamento> Departamentos { get; set; } 
        public DbSet<Funcionario> Funcionarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Funcionario>()
                .HasOne(f => f.Departamento)
                .WithMany(d => d.Funcionarios)
                .HasForeignKey(f => f.DepartamentoId);
        }
    }
}
