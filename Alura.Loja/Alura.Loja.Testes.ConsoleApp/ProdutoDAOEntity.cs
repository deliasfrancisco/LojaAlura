using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    //Classe de entity esta fazendo o mesmo que a calsse ProdutoDAO faz so que fazendo uso da entity, implementando aa intefaces
    // IProduto e IDisposible para ter acesso aos metodos
    class ProdutoDAOEntity : IProdutoDAO, IDisposable 
    {
        private LojaContext contexto; // variavel do tipo de contexto que representa classe entity que faz a conexão com a base de dados

        public ProdutoDAOEntity()
        {
            this.contexto = new LojaContext();
        }

        public void Adicionar(Produto p)
        {
            contexto.Produtos.Add(p); //em cada chamada ele sendo passado para a base de dados o que queremos fazer(aterar, excluir, inserir ou listar)
            contexto.SaveChanges();
        }

        public void Atualizar(Produto p)
        {
            contexto.Produtos.Update(p);
            contexto.SaveChanges();
        }

        public void Remover(Produto p)
        {
            contexto.Produtos.Remove(p);
            contexto.SaveChanges();
        }

        public IList<Produto> Produtos()
        {
            return contexto.Produtos.ToList();
        }

        public void Dispose()
        {
            contexto.Dispose();
        }


    }
}
