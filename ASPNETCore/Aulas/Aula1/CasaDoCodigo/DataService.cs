using CasaDoCodigo.Models;
using CasaDoCodigo.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using static CasaDoCodigo.Repositories.ProdutoRepository;

namespace CasaDoCodigo
{
	public partial class Startup
    {
		class DataService : IDataService
		{
			private readonly ApplicationContext contexto; //injecção de dependencias
			private readonly IProdutoRepository produtoRepository;

			public DataService(ApplicationContext contexto,
				IProdutoRepository produtoRepository)
			{
				this.contexto = contexto;
				this.produtoRepository = produtoRepository;
			}

			public void InicializaDB()
			{
				contexto.Database.EnsureCreated();

				List<Livro> livros = GetLivros();

				produtoRepository.SaveProdutos(livros);
			}

			private static List<Livro> GetLivros()
			{
				var json = File.ReadAllText("livros.json"); //vai fazer a a leitura do arquivo json
				var livros = JsonConvert.DeserializeObject<List<Livro>>(json);  // converte um arquivo json em objeto  //deserializar o objeto
				return livros;
			}
		}
	}
}
