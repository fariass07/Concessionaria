using System.ComponentModel.DataAnnotations;

namespace ProjetoSistema.Models
{
    public class Moto
    {
        public Moto()
        {

        }

        public Moto(string name, double id, double placa, string cor, int cilindrada, double ano)
        {
            Name = name;
            Id = id;
            Placa = placa;
            Cor = cor;
            Cilindrada = cilindrada;
            Ano = ano;
        }

        [Display (Name = "Modelo")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Name { get; set; }

        public double Id { get; set; }

        [Display(Name = "Número")]
        public double Placa { get; set; }

        public string Cor { get; set; }

        public int Cilindrada { get; set; }

        public double Ano { get; set; }
    }
}
