using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CasaDoCodigo.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static CasaDoCodigo.Repositories.CadastroRepository;
using static CasaDoCodigo.Repositories.ItemPedidoRepository;
using static CasaDoCodigo.Repositories.PedidoRepository;

namespace CasaDoCodigo
{
	public partial class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services) //método de configuração para o nosso banco de dados.
		{
			services.AddMvc();

			services.AddTransient<IDataService, DataService>();
			services.AddTransient<IProdutoRepository, ProdutoRepository>(); //criando uma instancia
			services.AddTransient<IPedidoRepository, PedidoRepository>(); //criando uma instancia
			services.AddTransient<IItemPedidoRepository, ItemPedidoRepository>(); //criando uma instancia
			services.AddTransient<ICadastroRepository, CadastroRepository>(); //criando uma instancia

			string connectionString = Configuration.GetConnectionString("Default");// definindo a conexão criada em appsettings

			services.AddDbContext<ApplicationContext>(optionsAction =>  // nome da classe do contexto do banco de dados ApplicationContext()
			optionsAction.UseSqlServer(connectionString)); // instanciando a classe de conexão que no caso e SQL server
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env, 
			IServiceProvider serviceProvider) // IServiceProvider -> vai fornecer o serviço da aplicação
		{
			if (env.IsDevelopment())
			{
				app.UseBrowserLink();
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}

			app.UseStaticFiles();

			app.UseMvc(routes =>
			{
				routes.MapRoute( //rota padrão
					name: "default",
					template: "{controller=Pedido}/{action=Carrossel}/{codigo?}");
			});

			serviceProvider.GetService<IDataService>()//gerando instacia a partir da interface
				.InicializaDB();
				//.Migrate();
			//.EnsureCreated();
			// metodo necessario que garante a criação do banco de bados caso ele não exista
			// uq ei feito atraves do paramtro do metodo IServiceProvider serviceProvider (injeção de dependencias)
		}
	}
}
