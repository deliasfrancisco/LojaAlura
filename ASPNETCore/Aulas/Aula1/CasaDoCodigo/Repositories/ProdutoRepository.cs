using CasaDoCodigo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CasaDoCodigo.Startup;

namespace CasaDoCodigo.Repositories
{
	public class ProdutoRepository : IProdutoRepository
	{
		private readonly ApplicationContext contexto;

		public ProdutoRepository(ApplicationContext contexto)
		{
			this.contexto = contexto;
		}

		public IList<Produto> GetProdutos()
		{
			return contexto.Set<Produto>().ToList(); //retorna como uma lista
		}

		public void SaveProdutos(List<Livro> livros)
		{
			foreach (var livro in livros)
			{
				contexto.Set<Produto>().Add(new Produto(livro.Nome, livro.Codigo, livro.Preco)); //adicionando informações na memoria
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
