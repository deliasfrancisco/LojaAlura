using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaEList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> idades = new List<int>(); //CRIAÇÃO DE UMA LISTA DE INTEIROS

            idades.Add(27);//
            idades.Add(12);//
            idades.Add(42);//  PREECHIMENTO DE UMA LISTA DE INTEIROS
            idades.Add(70);//
            idades.Add(5);//

            ListExtensoes.AdicionarVarios(idades, 1245, 1145, 55452);  //USO DA CLASSE ListExtensoes CRIADA COM UMA METODO DE LISTA PARA A ADIÇÃO DE VARIOS 
            //OBS: FOI FEITO USO DO PARAMS PARA NÃO HAVER A PREOCUPAÇÃO COM O TANTO DE PARAMETROS QUE SERÃO PASSADOS 

            idades.AdicionarVarios(45, 23, 41); //idade pode acessar o metodo da classe ListExtensoes diretamente pois foi feito apontado através do this que a lista esta acessivel diretamente para a classe que quiser acessalá diretamente

            for (int i = 0; i < idades.Count; i++)
            {
                Console.WriteLine(idades[i]); //LEITURA DA LIST A DE IDADES
            }

            Console.ReadLine();
        }
    }
}
