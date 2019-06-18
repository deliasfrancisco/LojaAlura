using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodoExtensaoEClasseGenerica.Estensoes
{
    public static class ListExtensoes<T> //precisa ser uma metodo static detro de uma classe static para poder ser acessado externamente
    {// <T> define o que a classe é do tipo generico
        public static void AdicionarVarios(this List<T> listaDeInteiros, params T[] itens)//criação de uma lista de inteiros e de um vetor sem tamanho definido porem com o argumento params que auto aloca uma tamanho de array
        {    //METODO ESTATICO                      QUE VAI ATUAR NESSA LISTA       PEGANDO OS ARGUMENTOS
            // foi feito uso do THIS que juntamente a visibilidade publica permite o acesso direto ao metodo, que também esta estatico
            foreach (T item in itens)
            {
                listaDeInteiros.Add(item);
            }
        }
        // uma lista generica abrange uma grande quantidade de itens (string, char, int, double)
    }
}
