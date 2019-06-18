using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //GravarUsandoAdoNet();
            GravarUsandoEntity();
        }

        private static void GravarUsandoAdoNet()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.Preco = 19.89;

            using (var repo = new ProdutoDAO())
            {
                repo.Adicionar(p);
            }
        }

        private static void GravarUsandoEntity()
        {
            var p = new Produto();
            p.Nome = "Harry Potter e a origem da fenix";
            p.Categoria = "Livros";
            p.Preco = 19.89;

            using (var repo = new LojaContext())
            {
                repo.Adicionar(p);
            }
        }
    }
}
