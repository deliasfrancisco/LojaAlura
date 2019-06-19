using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {

            var promocaoDePascoa = new Promocao();
            promocaoDePascoa.Descricao = "";
            promocaoDePascoa.DataInicio = DateTime.Now;
            promocaoDePascoa.DataFim = DateTime.Now.AddMinutes(3);
            //promocaoDePascoa.Produto.Add(new Produto()); 
            //promocaoDePascoa.Produto.Add(new Produto()); 
            //promocaoDePascoa.Produto.Add(new Produto());



            //compra de 6 paes franceses
            //var paoFrances = new Produto();
            //paoFrances.Nome = "pao Frances";
            //paoFrances.Categoria = "Padaria";
            //paoFrances.PrecoUnitario = 0.32;
            //paoFrances.Unidade = "Unidade";

            //var compra = new Compra();
            //compra.Quantidade = 6;
            //compra.Produto = paoFrances;
            //compra.Preco = (paoFrances.PrecoUnitario * compra.Quantidade);


            //using (var contexto = new LojaContext()) //criando um onjeto para acessar a classe Context
            //{
            //    contexto.Compra.Add(compra); //estou adicionando a compra na tabela de compra

            //    contexto.SaveChanges();

            //    ExibeEntries(contexto.ChangeTracker.Entries());

            //}

            Console.ReadLine();


            //    using (var contexto = new LojaContext())
            //    {
            //        var produtos = contexto.Produtos.ToList();// faz o select no banco

            //        ExibeEntries(contexto.ChangeTracker.Entries()); //exibe uma lista de produtos juntamente com seu estado

            //        var novoProduto = new Produto()
            //        {
            //            Nome = "São em Po",
            //            Categoria = "Limpeza",
            //            Preco = 4.99
            //        };
            //        contexto.Produtos.Add(novoProduto); // esta adicionando uma novo produto

            //        ExibeEntries(contexto.ChangeTracker.Entries());

            //        contexto.Produtos.Remove(novoProduto);

            //        ExibeEntries(contexto.ChangeTracker.Entries()); //exibe
            //        contexto.SaveChanges();//salva as mudancas

            //        var entry = contexto.Entry(novoProduto);

            //        ExibeEntries(contexto.ChangeTracker.Entries()); //exibe
            //        Console.WriteLine(entry.Entity.ToString() + "-" + entry.State);
            //    }
            //    Console.ReadLine();
            //}

            //private static void ExibeEntries(IEnumerable<EntityEntry> entries)
            //{
            //    Console.WriteLine("###################################");
            //    foreach (var c in entries)
            //    {
            //        Console.WriteLine(c.Entity.ToString() + "-" + c.State);
            //    }
            //}
        }

        private static void ExibeEntries(IEnumerable<EntityEntry> entries)
        {
            Console.WriteLine("###################################");
            foreach (var c in entries)
            {
                Console.WriteLine(c.Entity.ToString() + "-" + c.State);
            }
        }

    }
}
