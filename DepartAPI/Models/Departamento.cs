namespace DepartApi.Models
{
    public class Departamento
    {

        public Departamento() { }


        public Departamento(int Id, string Nome, string Sigla)
        {
            this.Id = Id;   
            this.Nome = Nome;
            this.Sigla = Sigla;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public List<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();
    }
}
