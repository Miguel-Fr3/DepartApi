namespace DepartApi.Models
{
    public class Departamentos
    {

        public Departamentos() { }


        public Departamentos(int Id, string Nome, string Sigla)
        {
            this.Id = Id;   
            this.Nome = Nome;
            this.Sigla = Sigla;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public List<Funcionarios> Funcionarios { get; set; } = new List<Funcionarios>();
    }
}
