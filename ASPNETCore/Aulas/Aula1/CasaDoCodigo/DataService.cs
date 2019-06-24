using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace CasaDoCodigo
{
	public partial class Startup
    {
		class DataService : IDataService
		{
			private readonly ApplicationContext contexto;

			public DataService(ApplicationContext contexto)
			{
				this.contexto = contexto;
			}

			public void InicializaDB()
			{
				contexto.Database.EnsureCreated();

				var json = File.ReadAllText("livros.json"); //vai fazer a a leitura do arquivo json
				var livros = JsonConvert.DeserializeObject<List<Livro>>(json);  // converte um arquivo json em objeto
			}
		}

		class Livro
		{
			public string Codigo { get; set; }
			public string Nome { get; set; }
			public decimal Preco { get; set; }
		}

	}
}
