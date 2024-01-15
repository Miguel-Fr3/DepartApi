using DepartApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DepartApi.Data
{
    public class DataContext : DbContext
    {



        public DataContext(DbContextOptions<DataContext> options) : base (options) { }

        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Departamento>()
                .HasData(new List<Departamento>(){
                    new Departamento(1, "Inovação Tecnológica", "IT"),
                    new Departamento(2, "Recursos Humano", "RH"),
                    new Departamento(3, "Financeiro", "FIN"),
                    new Departamento(4, "Marketing", "MK"),
                    new Departamento(5, "Desenvolvimento de Software", "DEV"),

                });

            builder.Entity<Funcionario>()
                .HasData(new List<Funcionario>(){
                    new Funcionario(1, "Miguel", "https://picsum.photos/100/100", "987654321", 5),
                    new Funcionario(2, "Heloisa", "https://picsum.photos/100/100", "123456789", 1),
                    new Funcionario(3, "Mariana", "https://picsum.photos/100/100", "916782345", 2),
                    new Funcionario(4, "Lucas", "https://picsum.photos/100/100", "456237891", 4),
                    new Funcionario(5, "Luis", "https://picsum.photos/100/100", "912345678", 3),
                });




        }
    }
}