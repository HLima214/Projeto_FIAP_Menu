using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_FIAP_Menu
{
    public class Carro
    {
        public String Marca { get; set; }

        public String Modelo { get; set; }

        public int Ano { get; set; }

        public double Valor { get; set; }


        private String ValorCompra { get; set; }

        public void ExibirDados()
        {
            Console.WriteLine($"Marca: {Marca} - Modelo: {Modelo} - Ano: {Ano} - Valor: {Valor:F2}");
        }

        public string GerarLinhaArquivos()
        {
            return $"{Marca} ; {Modelo} ; {Ano} ; {Valor}";      
        }
    }
}
