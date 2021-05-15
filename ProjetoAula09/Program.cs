using ProjetoAula09.Controllers;
using System;

namespace ProjetoAula09
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SISTEMA DE CADASTRO E CONSULTA DE PRODUTOS");

            var produtoController = new ProdutoController();
            Console.WriteLine("\n\n");
            Console.WriteLine("(1) CADASTRO DE PRODUTO");
            Console.WriteLine("(2) CONSUTA DE PRODUTOS");
            Console.WriteLine("(3) ATUALIZAÇÃO DE PRODUTO");
            Console.WriteLine("(4) EXCLUSÃO DE PRODUTO");
            Console.WriteLine("(0) SAIR DO SISTEMA");
            Console.WriteLine("\n");

            try
            {
                Console.Write("INFORME A OPÇAO DESEJADA: ");
                var opção = int.Parse(Console.ReadLine());

                switch (opção)
                {
                    case 1:
                        produtoController.Cadastrar();
                        Main(args);
                        break;

                    case 2:
                        produtoController.Consultar();
                        Main(args);
                        break;

                    case 3:
                        produtoController.Atualizar();
                        Main(args);
                        break;

                    case 4:
                        produtoController.Excluir();
                        Main(args);
                        break;

                    case 0:
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\n Erro!" + e.Message);
            }
            Console.ReadKey();

        }
    }
}
