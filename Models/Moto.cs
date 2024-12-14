using System.ComponentModel.DataAnnotations;

namespace ProjetoSistema.Models
{
    public class Moto
    {
        public Moto()
        {

        }

        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public string Cor { get; set; }
        public int Cilindrada { get; set; }
        public int Ano { get; set; }

        public Moto(int id, string marca, string modelo, string placa, string cor, int cilindrada, int ano)
        {
            Id = id;
            Marca = marca;
            Modelo = modelo;
            Placa = placa;
            Cor = cor;
            Cilindrada = cilindrada;
            Ano = ano;
        }

        
    }
}
