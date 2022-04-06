using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestordeClientesCMD
{
    internal class Program
    {
        [System.Serializable]
        struct Cliente
        {
            public string Nome;
            public string email;
            public string cpf;
        }

        static List<Cliente> Clientes = new List<Cliente>();

        enum Menu { Listagem = 1, Adicionar = 2, Remover = 3, Sair = 4 };

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            bool escolheuSair = false;

            while (!escolheuSair)
            {
                Console.WriteLine("====================================");
                Console.WriteLine("Bem Vindo ao Gestor de Clientes CMD");
                Console.WriteLine("Selecione a Opção desejada");
                Console.WriteLine("====================================");
                Console.WriteLine("1 - Listagem\n2 - Adicionar\n3 - Remover\n4 - Sair");

                int intOp = int.Parse(Console.ReadLine());
                Menu opcao = (Menu)intOp;

                Console.Clear();

                switch (opcao)
                {
                    case Menu.Listagem:
                        break;
                    case Menu.Adicionar:
                        Adicionar();
                        break;
                    case Menu.Remover:
                        break;
                    case Menu.Sair:
                        escolheuSair = true;
                        break;
                    default:
                        break;
                }



                Console.Clear();
            }
        }

        static void Adicionar()
        {
            Cliente cliente = new Cliente();
            Console.WriteLine("Cadastro de Cliente: ");
            Console.WriteLine("Nome do Cliente: ");
            cliente.Nome = Console.ReadLine();
            Console.WriteLine("Email do Cliente: ");
            cliente.email = Console.ReadLine();
            Console.WriteLine("CPF do Cliente: ");
            cliente.cpf = Console.ReadLine();

            Clientes.Add(cliente);

            Console.WriteLine("Cadastro Concluído, Aperte enter para sair");
            Console.ReadLine();
        }
    }
}
