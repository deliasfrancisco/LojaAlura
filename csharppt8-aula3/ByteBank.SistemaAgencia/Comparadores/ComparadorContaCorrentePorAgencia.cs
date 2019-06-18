using ByteBank.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia.Comparadores
{
    public class ComparadorContaCorrentePorAgencia : IComparer<ContaCorrente> //inteface Icomparer
    {
        // se x for igual a y retornar 
        // se x e y forem equivalentes retornar zero 
        // se y tiver uma precendencia maior  que x retornar positivo
        public int Compare(ContaCorrente x, ContaCorrente y)
        {
            return x.Agencia.CompareTo(x.Agencia);
                                                      
            if (x == y)                         //     <..
            {                                    //       `.
                return 0;                          //       `.    
            }                                        //       )
                                                       //     |
            if (x == null)                               //   |
            {                                              // |
                return 1;        //                           |
            }                      //                         |  O CODIGO FEITO JÁ É IMPLEMENTADO PELO .NET
                                     //                       | 
            if (y == null)             //                     |
            {                            //                   |
                return -1;                 //                |
            }                                //             /
                                               //          /
            if (x.Agencia < y.Agencia)           //      .´
            {                                      //  .´
                return -1; //x fica na fernte y    //-´
            }
            if (x.Agencia == y.Agencia)
            {
                return 0; //são equivalentes
            }
            return 1; //y fica na frente de x 

            // As comparações de numeros inteiros é equivalente ao que ja existe no tipo int
            // ctrl + k + C comenta um bloco de texto
            // ctrl + k + U descomenta um bloco de texto
        }
    }
}
