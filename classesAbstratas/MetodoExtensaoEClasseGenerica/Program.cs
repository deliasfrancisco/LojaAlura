using MetodoExtensaoEClasseGenerica.Beans;
using MetodoExtensaoEClasseGenerica.Controllers;
using MetodoExtensaoEClasseGenerica.Estensoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodoExtensaoEClasseGenerica
{
    class Program
    {
        static void Main(string[] args)
        {
            var idades = new List<int>(); //CRIAÇÃO DE UMA LISTA DE INTEIROS
            idades.Add(27);//
            idades.Add(12);//
            idades.Add(42);//  PREECHIMENTO DE UMA LISTA DE INTEIROS
            idades.Add(70);//
            idades.Add(5);//// ListExtensoes.AdicionarVarios(idades, 1245, 1145, 55452);  //USO DA CLASSE ListExtensoes CRIADA COM UMA METODO DE LISTA PARA A ADIÇÃO DE VARIOS  //OBS: FOI FEITO USO DO PARAMS PARA NÃO HAVER A PREOCUPAÇÃO COM O TANTO DE PARAMETROS QUE SERÃO PASSADOS 
            idades.AdicionarVarios(45, 23, 41); //idade pode acessar o metodo da classe ListExtensoes diretamente pois foi feito apontado através do this que a lista esta acessivel diretamente para a classe que quiser acessalá diretamente
            idades.Sort(); //sort() -> faz a ordenação dos numeros

            for (var i = 0; i < idades.Count; i++)
            {
                Console.WriteLine(idades[i]); //LEITURA DA LIST A DE IDADES

            }

            List<string> nomes = new List<string>();
            nomes.AdicionarVarios("Diego Francisco", "Diego Elias", "Laisla", "Mãe", "Zenaide", "Abel"); //podemos ver que o metodo generico com <T> que esta sendo chamado aceita a passafem de qualquer tipo de parametro pois o proprio Visual Studio interpreta define o tipo da variavel
            nomes.Sort(); //funciona com todos os tipos

            for(var i = 0;  i < nomes.Count; i++)
            {
                Console.WriteLine(nomes[i]);
            }

            var exemplo1 = new int();     //exemplos de o tipo de variavel var assume o tipo de qualquer variavel, desde as primarias quanto as que criamos
            var exemlpo3 = new double();  //

            // o tipo de variavel object assume as propriedades de qualquer variavel reservada, como string, int, double, porem tipos craidos (Conta, Pessoa) ele não consegue asssumir

            Console.ReadLine();



        }
    }
}
