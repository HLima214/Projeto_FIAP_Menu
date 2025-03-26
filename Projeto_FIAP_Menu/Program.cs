using Projeto_FIAP_Menu;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace RM_2503
{
    class Program
    {
        static List<Carro> listaCarros = new List<Carro>();
        static void Main(string[] args)
        {
            if (Login())
            {
                Menu();
            }
        }
        static bool Login()
        {
            int tentativas = 0;
            string usuarioCorreto = "Henrique";
            string senhaCorreta = "551528";
            while (tentativas < 3)
            {
                Console.Write("Usuário: ");
                string usuario = Console.ReadLine();
                Console.Write("Senha (RM: ");
                string senha = Console.ReadLine();
                if (usuario == usuarioCorreto && senha == senhaCorreta)
                {
                    Console.WriteLine("Login realizado com sucesso!");
                    return true;
                }
                tentativas++;
                Console.WriteLine($"Usuário ou senha inválidos! Restam: {3 - tentativas}  ");
            }
            Console.WriteLine("Número máximo de tentativas excedido.!");
            return false;
        }
        //static void CadastrarCliente()
        //{
        //    Console.Write("Nome completo: ");
        //    string nome = Console.ReadLine();
        //    Console.Write("Data de nascimento (dd/mm/aaaa): ");
        //}

        static void CadastrarVeiculo()
        {
            Carro carro = new Carro();
            Console.Write("Marca: ");
            carro.Marca = Console.ReadLine();
            Console.Write("Modelo: ");
            carro.Modelo = Console.ReadLine();
            Console.Write("Ano: ");
            carro.Ano = Convert.ToInt32(Console.ReadLine());
            //do
            //{
            Console.Write("Valor (mínimo R$60.000): ");
            carro.Valor = Convert.ToDouble(Console.ReadLine());
            if (carro.Valor < 60000)
            {
                Console.WriteLine("Valor inválido. Deve ser acima de R$60.000.");
            }

            //} while (carro.Valor > 60000);
            listaCarros.Add(carro);
        }
        static void Exportartxt()
        {
            string caminho = "veiculos.txt";
            using (StreamWriter writer = new StreamWriter(caminho))
            {
                foreach (Carro carro in listaCarros)
                {
                    writer.WriteLine(carro.GerarLinhaArquivos());
                }
            }
            Console.WriteLine($"Veículos salvos com sucesso em '{caminho}'");
        }
        static void ListarVeiculos()
        {
            if (listaCarros.Count == 0)
            {
                Console.WriteLine("Nenhum veículo cadastrado.");
                return;
            }
            Console.WriteLine("\nLista de veículos:");
            foreach (Carro carro in listaCarros)
            {
                carro.ExibirDados();
            }
        }

        static void Menu()
        {
            int opcao;
            do
            {
                Console.WriteLine("\nMENU:");
                Console.WriteLine("1 - Cadastrar cliente");
                Console.WriteLine("2 - Cadastrar veículo");
                Console.WriteLine("3 - Listar veículos");
                Console.WriteLine("4 - Exportar veículos cadastrados");
                Console.WriteLine("5 - Sair");
                Console.Write("Escolha: ");
                opcao = Convert.ToInt32(Console.ReadLine());
                switch (opcao)
                {
                    //    case 1: CadastrarCliente(); break;
                    case 2: CadastrarVeiculo(); break;
                    case 3: ListarVeiculos(); break;
                    case 4: Exportartxt(); break;
                    case 5: Console.WriteLine("Encerrando..."); break;
                    default: Console.WriteLine("Opção inválida."); break;
                }
            } while (opcao != 5);
        }
    }
}
