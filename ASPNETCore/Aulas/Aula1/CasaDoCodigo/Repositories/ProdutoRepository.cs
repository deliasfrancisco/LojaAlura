using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
	public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
	{
        public ProdutoRepository(ApplicationContext contexto) : base(contexto) //construtor que irá passar o contexto para a classe base
        {

        }

        public IList<Produto> GetProdutos()
		{
			return dbSet.ToList(); //retorna como uma lista
		}

		public void SaveProdutos(List<Livro> livros)
		{
			foreach (var livro in livros)
			{
                if (!dbSet.Where(p => p.Codigo == livro.Codigo).Any()) //ira fazer a verificação se há codigo duplicado, se não for igual ele adiciona o livro, se for ele vai para proxima volta do foreach any retrona verdadeiro ou falso
                {
                    dbSet.Add(new Produto(livro.Codigo, livro.Nome, livro.Preco)); //adicionando informações na memoria
                }
			}
			contexto.SaveChanges(); //salvando a listagem de produtos na tabela de produtos
		}
		public class Livro
		{
			public string Codigo { get; set; }
			public string Nome { get; set; }
			public decimal Preco { get; set; }
		}
	}
}
