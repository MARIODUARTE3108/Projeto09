using ProjetoAula09.Entities;
using ProjetoAula09.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoAula09.Controllers
{
    public class ProdutoController
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BD_Aula09;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public void Cadastrar()
        {
            try
            {

                var produto = new Produto();

                Console.WriteLine("\n Cadastro de Produto: ");

                Console.Write("Informe o Nome do Poduto: ");
                produto.Nome = Console.ReadLine();

                Console.Write("Informe o preço do Poduto: ");
                produto.Preco = decimal.Parse(Console.ReadLine());

                Console.Write("Informe a quantidade da Poduto: ");
                produto.Quantidade = int.Parse(Console.ReadLine());

                Console.Write("Informa data de validade do Poduto: ");
                produto.DataValidade = DateTime.Parse(Console.ReadLine());

                var produtoRepository = new ProdutoRepository();
                produtoRepository.ConnectionString = connectionString;
                produtoRepository.Inserir(produto);

                Console.WriteLine("\nProduto cadastrado com sucesso! ");
                Console.WriteLine("\n\n");
            }
            catch (Exception e )
            {
                Console.WriteLine("\n Erro!" + e.Message);
            }

        }

         public void Atualizar()
        {
            try
            {
                Console.WriteLine("\n Atualização de produto!");

                Console.Write("Informe o Id do produto: ");
                var idProduto = Guid.Parse(Console.ReadLine());

                var produtoRepository = new ProdutoRepository();
                produtoRepository.ConnectionString = connectionString;

                var produto = produtoRepository.ObterPorId(idProduto);

                if (produto != null)
                {
                    Console.Write("Informe o Nome do Poduto: ");
                    produto.Nome = Console.ReadLine();

                    Console.Write("Informe o preço do Poduto: ");
                    produto.Preco = decimal.Parse(Console.ReadLine());

                    Console.Write("Informe a quantidade da Poduto: ");
                    produto.Quantidade = int.Parse(Console.ReadLine());

                    Console.Write("Informa data de validade do Poduto: ");
                    produto.DataValidade = DateTime.Parse(Console.ReadLine());

                    produtoRepository.Atualizar(produto);

                    Console.WriteLine("\n PRODUTO ATUALIZADO COM SUCESSO!");
                    Console.WriteLine("\n\n");
                }
                else
                {
                    Console.WriteLine("\n Produto no encontrado");
                    Console.WriteLine("\n\n");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("\n Erro! " + e.Message);
            }

        }

        public void Excluir()
        {
            try
            {
                Console.WriteLine("\n Exclusão de Produto");

                Console.Write("Informe o Id do Produto: ");
                var idProduto = Guid.Parse(Console.ReadLine());

                var produtoRepository = new ProdutoRepository();
                produtoRepository.ConnectionString = connectionString;

                var produto = produtoRepository.ObterPorId(idProduto);

                if (produto != null)
                {
                    produtoRepository.Excluir(produto);
                    Console.WriteLine("\n PRODUTO EXCUIDO COM SUCESSO!");
                    Console.WriteLine("\n\n");
                }
                else
                {
                    Console.WriteLine("\n Produto no encontrado");
                    Console.WriteLine("\n\n");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("\n ERRO!" + e.Message);
            }
        }
          public void Consultar()
          {
            try
            {
                Console.WriteLine("\nConsulta de Produtos");

                var produtoRepository = new ProdutoRepository();
                produtoRepository.ConnectionString = connectionString;

                var produtos = produtoRepository.ObterTodos();

                foreach (var item in produtos)
                {
                    Console.WriteLine("ID DO PRODUTO................: " + item.IdProduto);
                    Console.WriteLine("NOME DO PRODUTO..............: " + item.Nome);
                    Console.WriteLine("PREÇO DO PRODUTO.............: " + item.Preco);
                    Console.WriteLine("QUANTIDADE DO PRODUTO........: " + item.Quantidade);
                    Console.WriteLine("DATA DE VALIDADE DO PRODUTO..: " + item.DataValidade);
                    Console.WriteLine("--------------");
                    Console.WriteLine("\n");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("\n Erro!" + e.Message);
            }

          }

        }
}
