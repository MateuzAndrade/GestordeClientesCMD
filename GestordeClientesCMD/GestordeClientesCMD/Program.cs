using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


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

        static List<Cliente> clientes = new List<Cliente>();

        enum Menu { Listagem = 1, Adicionar = 2, Remover = 3, Sair = 4 };

        static void Main(string[] args)
        {
            Carrregar();
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
                        Listagem();
                        break;
                    case Menu.Adicionar:
                        Adicionar();
                        break;
                    case Menu.Remover:
                        Remover();
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

        static void Listagem()
        {
            Console.WriteLine("====================================");
            Console.WriteLine("Lista de Clientes");
            Console.WriteLine("====================================\n");

            if (clientes.Count > 0)
            {
                int id = 0;
                foreach (Cliente cliente in clientes)
                {
                    Console.WriteLine($"Cliente ID: {id}");
                    Console.WriteLine($"Nome: {cliente.Nome}");
                    Console.WriteLine($"E-mail: {cliente.email}");
                    Console.WriteLine($"CPF: {cliente.cpf}\n");
                    id++;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nenhum cliente cadastrado!\n");
                Console.ForegroundColor = ConsoleColor.Blue;

            };

            Console.WriteLine("Pressione enter para continuar.");
            Console.ReadLine();
        }

        static void Adicionar()
        {
            Cliente cliente = new Cliente();
            Console.WriteLine("====================================");
            Console.WriteLine("Cadastro de Cliente");
            Console.WriteLine("====================================\n");
            Console.WriteLine("Nome do Cliente: ");
            cliente.Nome = Console.ReadLine();
            Console.WriteLine("Email do Cliente: ");
            cliente.email = Console.ReadLine();
            Console.WriteLine("CPF do Cliente: ");
            cliente.cpf = Console.ReadLine();

            clientes.Add(cliente);
            Salvar();

            Console.WriteLine("Cadastro Concluído, Aperte enter para sair");
            Console.ReadLine();
        }

        static void Salvar()
        {
            FileStream stream = new FileStream("clients.txt", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            encoder.Serialize(stream, clientes);

            stream.Close();

        }

        static void Carrregar()
        {
            FileStream stream = new FileStream("clients.dat", FileMode.OpenOrCreate);

            try
            {
                BinaryFormatter encoder = new BinaryFormatter();

                clientes = (List<Cliente>)encoder.Deserialize(stream);

                if (clientes == null)
                {
                    clientes = new List<Cliente>();

                }

            }
            catch (Exception)
            {
                clientes = new List<Cliente>();
            }

            stream.Close();

        }

        static void Remover()
        {
            Listagem();
            Console.WriteLine("========================================");
            Console.WriteLine("Digite o ID do Cliente que você quer remover");
            Console.WriteLine("========================================\n");
            int id = int.Parse(Console.ReadLine());

            if (id >= 0 && id < clientes.Count)
            {
                clientes.RemoveAt(id);
                Console.WriteLine($"Você tem certeza que deseja deletar o Cliente de ID {id} ?");
                Console.WriteLine("Pressione enter para continuar.");
                Console.ReadLine();
                Salvar();
                Console.WriteLine($"Cliente {id} deletado com Sucesso.");
            }
            else
            {
                Console.WriteLine("ID do Cliente digitado não Existe.");
                Console.WriteLine("Pressione enter para retornar ao inicio.");
                Console.ReadLine();
            }

        }

    }
}
