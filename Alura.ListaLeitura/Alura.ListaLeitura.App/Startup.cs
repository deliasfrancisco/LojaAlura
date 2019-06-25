using Alura.ListaLeitura.App.Mvc;
using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting(); //a apicação esta utilizando o servico de roteamento do ASP.NET Core
        }

        public void Configure(IApplicationBuilder app)
        {
            var builder = new RouteBuilder(app);
            builder.MapRoute("{classe}/{metodo}", RoteamentoPadrao.TratamentoPadrao);
            var rotas = builder.Build();

            app.UseRouter(rotas);

        }

        public Task PrecessaFormulario(HttpContext context)
        {
            var livro = new Livro()
            {
                //Titulo = context.Request.Query["titulo"].First(),
                Titulo = context.Request.Form["titulo"].First(),
                //Autor = context.Request.Query["autor"].First(),
                Autor = context.Request.Form["autor"].First(),
            };

            var _repo = new LivroRepositorioCSV();
            _repo.Incluir(livro);

            return context.Response.WriteAsync("O livro foi adicionado com sucesso");
        }

        public Task ExibeFormulario(HttpContext context)
        {
            var html = CarregaArquivoHtml("formulario"); 
            //o caractere @ permite que seja escrito mais de uma linha
            // o atributo action deterina qual é a rota que o formulario sera enviado para processanmento
            // name -> identifica o valor que esta sendo vindo por parametro de entrada
            //label -> tag para escrever o titulo para determinado campo
            //br -> Pula linha no formulario

            return context.Response.WriteAsync(html); // retornando o formulario que foi escrito acima 
        }

        public string CarregaArquivoHtml(string nomeArquivo)
        {
            var nomeCompletoArquivo = $"HTML/{nomeArquivo}.html"; //interpolação de strings
            using (var arquivo = File.OpenText(nomeCompletoArquivo))
            {
                return arquivo.ReadToEnd(); //pega todo conteudo de inicio ao fim e colocar em uma string 

            }
        }

        public Task ExibeDetalhes(HttpContext context)
        {
            int id = Convert.ToInt32(context.GetRouteValue("id"));
            var repo = new LivroRepositorioCSV();
            var livro = repo.Todos.First(l => l.Id == id);
            return context.Response.WriteAsync(livro.Detalhes());
        }

        public Task NovoLivroParaLer(HttpContext context)
        {
            var livro = new Livro()
            {
                Titulo = Convert.ToString(context.GetRouteValue("nome")),
                Autor = Convert.ToString(context.GetRouteValue("autor"))
            };

            var _repo = new LivroRepositorioCSV();
            _repo.Incluir(livro);
            return context.Response.WriteAsync("O livro foi adicionado com sucesso");
        }

        public Task Roteamento(HttpContext context) // o http context contem todas as informações necessarias para estabelecer a conexão
        {
            var _repo = new LivroRepositorioCSV();
            var caminhosAtendidos = new Dictionary<string, RequestDelegate> //criação de uma dicionario
            {
                { "/Livros/ParaLer", LivrosParaLer}, //tre tipo de requisção tratadas a partir dos caminhos
                { "Livros/Lendo", LivrosLendo},
                { "Livros/Lidos", LivrosLidos}
                //{ "/Livros/ParaLer", _repo.ParaLer.ToString()}, //tre tipo de requisção tratadas a partir dos caminhos
                //{ "Livros/Lendo", _repo.Lendo.ToString()},
                //{ "Livros/Lidos", _repo.Lidos.ToString()}
            };

            if (caminhosAtendidos.ContainsKey(context.Request.Path))
            {
                var metodo = caminhosAtendidos[context.Request.Path];
                return metodo.Invoke(context); //dessa maneira foi isolado o tratamento de cada requisição de cada metodo
            }

            context.Response.StatusCode = 404; //tratamento de acesso no browser, caso o usuario tente acessar uma pagina que nos servidor não disponibile ele da uma retorno  no browser de erro 404
            //return context.Response.WriteAsync("Caminho inexistente");    // propriedade para a requisção (Request) e o endereço que pega o endereço do dominio e faz o roteamento (Path)
            return context.Response.WriteAsync("Caminho inexistente");    // propriedade para a requisção (Request) e o endereço que pega o endereço do dominio e faz o roteamento (Path)
        }



        public Task LivrosParaLer(HttpContext context)
        {
            var conteudoArquivo = CarregaArquivoHtml("para-ler");
            var _repo = new LivroRepositorioCSV();
            return context.Response.WriteAsync(conteudoArquivo); //propriedade do context para a resposta
        }

        public Task LivrosLendo(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            return context.Response.WriteAsync(_repo.Lendo.ToString()); //propriedade do context para a resposta
        }

        public Task LivrosLidos(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            return context.Response.WriteAsync(_repo.Lidos.ToString()); //propriedade do context para a resposta
        }
    }
}