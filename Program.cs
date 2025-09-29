using System;
using System.Collections.Generic;

namespace MyApp
{
    class Produto
    {
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public double Preco { get; set; }

        public Produto(string nome, int quantidade, double preco)
        {
            Nome = nome;
            Quantidade = quantidade;
            Preco = preco;
        }

        public override string ToString()
        {
            return $"{Nome} | Quantidade: {Quantidade} | Preço: R$ {Preco:F2}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Produto> produtos = new List<Produto>();

            Console.WriteLine("===== Sistema de Controle de Estoque =====\n");
            Console.Write("Digite seu nome: ");
            string nomeUsuario = Console.ReadLine();
            Console.WriteLine($"Seja bem-vindo, {nomeUsuario}!\n");

            string opcao;
            do
            {
                Console.WriteLine("\n===== MENU =====");
                Console.WriteLine("1 - Cadastrar Produto");
                Console.WriteLine("2 - Listar Produtos");
                Console.WriteLine("3 - Excluir Produto");
                Console.WriteLine("4 - Quantidade de Produtos Cadastrados");
                Console.WriteLine("5 - Atualizar Quantidade");
                Console.WriteLine("6 - Valor Total do Estoque");
                Console.WriteLine("7 - Detalhes de um Produto");
                Console.WriteLine("8 - Sair");
                Console.Write("Escolha uma opção: ");
                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Console.Write("Digite o nome do produto: ");
                        string nome = Console.ReadLine();
                        Console.Write("Digite a quantidade: ");
                        int quantidade = int.Parse(Console.ReadLine());
                        Console.Write("Digite o preço: ");
                        double preco = double.Parse(Console.ReadLine());

                        Produto novoProduto = new Produto(nome, quantidade, preco);
                        produtos.Add(novoProduto);
                        Console.WriteLine("Produto cadastrado!");
                        break;

                    case "2":
                        Console.WriteLine("\n=== Produtos Cadastrados ===");
                        if (produtos.Count == 0)
                            Console.WriteLine("Nenhum produto cadastrado.");
                        else
                            foreach (Produto p in produtos)
                                Console.WriteLine(p);
                        break;

                    case "3":
                        Console.Write("Digite o nome do produto a excluir: ");
                        string remover = Console.ReadLine();
                        Produto encontrado = null;

                        foreach (Produto p in produtos)
                        {
                            if (p.Nome == remover)
                            {
                                encontrado = p;
                                break;
                            }
                        }

                        if (encontrado != null)
                        {
                            produtos.Remove(encontrado);
                            Console.WriteLine("Produto removido!");
                        }
                        else
                        {
                            Console.WriteLine("Produto não encontrado.");
                        }
                        break;

                    case "4":
                        Console.WriteLine($"Total de produtos cadastrados: {produtos.Count}");
                        break;

                    case "5":
                        Console.Write("Digite o nome do produto para atualizar: ");
                        string nomeAtualizar = Console.ReadLine();
                        Produto prodAtualizar = null;

                        foreach (Produto p in produtos)
                        {
                            if (p.Nome == nomeAtualizar)
                            {
                                prodAtualizar = p;
                                break;
                            }
                        }

                        if (prodAtualizar != null)
                        {
                            Console.Write("Digite a nova quantidade: ");
                            int novaQtd = int.Parse(Console.ReadLine());
                            prodAtualizar.Quantidade = novaQtd;
                            Console.WriteLine("Quantidade atualizada!");
                        }
                        else
                        {
                            Console.WriteLine("Produto não encontrado.");
                        }
                        break;

                    case "6":
                        double valorTotal = 0;
                        foreach (Produto p in produtos)
                        {
                            valorTotal += p.Quantidade * p.Preco;
                        }
                        Console.WriteLine($"Valor total em estoque: R$ {valorTotal:F2}");
                        break;

                    case "7":
                        Console.Write("Digite o nome do produto: ");
                        string nomeBusca = Console.ReadLine();
                        Produto prodBusca = null;

                        foreach (Produto p in produtos)
                        {
                            if (p.Nome == nomeBusca)
                            {
                                prodBusca = p;
                                break;
                            }
                        }

                        if (prodBusca != null)
                            Console.WriteLine(prodBusca);
                        else
                            Console.WriteLine("Produto não encontrado.");
                        break;

                    case "8":
                        Console.WriteLine("Saindo do sistema... Até logo!");
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            } while (opcao != "8");
        }
    }
}