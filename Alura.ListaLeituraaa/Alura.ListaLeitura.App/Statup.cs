using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App
{
    public class Statup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.Run(LivrosParaLer);
        }

        public Task LivrosParaLer(HttpContext context)//toda informação de uma requisição espécifica fica armazenados em objetos do tipo HttpPost
        {

            var _repo = new LivroRepositorioCSV();
            return context.Response.WriteAsync(_repo.ParaLer.ToString()); //retorna uma reposta ao navegador que ira acessar os livros que serão feita a leitura
            
        }

    }
}