using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Hosting;
using System;

namespace Alura.ListaLeitura.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var _repo = new LivroRepositorioCSV();

            IWebHost host = new WebHostBuilder()// 1º - apos a implementação no terminal nuget do pacote WebHosting, etsa sendo instaciado um objeto de construção da nconexão
                .UseKestrel() //2º - diz qual é o servidor que implementa o modelo HTTP
                .UseStartup<Statup>() //3º - define a partir de qual classe sar feita a inicialização da aplicação
                .Build(); 
            host.Run(); //4º - executa a aplicação


            //ImprimeLista(_repo.ParaLer);
            //ImprimeLista(_repo.Lendo);
            //ImprimeLista(_repo.Lidos);
        }

        static void ImprimeLista(ListaDeLeitura lista)
        {
            Console.WriteLine(lista);
        }
    }
}
