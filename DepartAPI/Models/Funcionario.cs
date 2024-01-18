namespace DepartApi.Models
{
    public class Funcionarios
    {
        public Funcionarios() { }


        public Funcionarios(int Id, string Nome, string Foto, string RG, int DepartamentoId)
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

    }
}
