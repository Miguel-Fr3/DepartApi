namespace DepartApi.Models
{
    public class Funcionario
    {
        public Funcionario() { }


        public Funcionario(int Id, string Nome, string Foto, string RG, int DepartamentoId)
        {
            this.Id = Id;
            this.Nome = Nome;
            this.Foto = Foto;
            this.RG = RG;
            this.DepartamentoId = DepartamentoId;
            
        }    

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Foto { get; set; }
        public string RG { get; set; }
        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }
    }
}
