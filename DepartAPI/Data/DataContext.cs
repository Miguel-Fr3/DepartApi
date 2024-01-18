using DepartApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DepartApi.Data
{
    public class DataContext : DbContext
    {



        public DataContext(DbContextOptions<DataContext> options) : base (options) { }

        public DbSet<Departamentos> Departamentos { get; set; }
        public DbSet<Funcionarios> Funcionarios { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Departamentos>()
                .HasData(new List<Departamentos>(){
                    new Departamentos(1, "Inovação Tecnológica", "IT"),
                    new Departamentos(2, "Recursos Humano", "RH"),
                    new Departamentos(3, "Financeiro", "FIN"),
                    new Departamentos(4, "Marketing", "MK"),
                    new Departamentos(5, "Desenvolvimento de Software", "DEV"),

                });

            builder.Entity<Funcionarios>()
                .HasData(new List<Funcionarios>(){
                    new Funcionarios(1, "Miguel", "https://picsum.photos/100/100", "987654321", 5),
                    new Funcionarios(2, "Heloisa", "https://picsum.photos/100/100", "123456789", 1),
                    new Funcionarios(3, "Mariana", "https://picsum.photos/100/100", "916782345", 2),
                    new Funcionarios(4, "Lucas", "https://picsum.photos/100/100", "456237891", 4),
                    new Funcionarios(5, "Luis", "https://picsum.photos/100/100", "912345678", 3),
                });




        }
    }
}