using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CasaDoCodigo
{
	public partial class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();

			services.AddTransient<IDataService, DataService>();

			string connectionString = Configuration.GetConnectionString("Default");// definindo a conexão criada em appsettings

			services.AddDbContext<ApplicationContext>(optionsAction =>
			optionsAction.UseSqlServer(connectionString)); // instanciando a classe de conexão que no caso e SQL server
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider) // IServiceProvider -> vai fornecer o serviço da aplicação
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
					template: "{controller=Pedido}/{action=Carrossel}/{id?}");
			});

			serviceProvider.GetService<IDataService>()
				.InicializaDB();
				//.Migrate();
			//.EnsureCreated();
			// metodo necessario que garante a criação do banco de bados caso ele não exista
			// uq ei feito atraves do paramtro do metodo IServiceProvider serviceProvider (injeção de dependencias)
		}
	}
}
