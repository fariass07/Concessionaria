using System.ComponentModel.DataAnnotations;

namespace ProjetoSistema.Models
{
    public class Moto
    {
        public Moto()
        {

        }

        public Moto(string marca, string modelo, int id, string placa, string cor, int cilindrada, int ano)
        {
            Modelo = Modelo;
            Id = id;
            Marca = marca;
            Placa = placa;
            Cor = cor;
            Cilindrada = cilindrada;
            Ano = ano;
        }

        [Display (Name = "Modelo")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Modelo { get; set; }

        public string Marca { get; set; }

        public int Id { get; set; }
        public string Placa { get; set; }

        public string Cor { get; set; }

        public int Cilindrada { get; set; }

        public int Ano { get; set; }
    }
}
