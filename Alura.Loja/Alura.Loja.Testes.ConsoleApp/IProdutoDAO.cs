using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    interface IProdutoDAO
    {
        void Atualizar(Produto p);
        void Adicionar(Produto p);
        void Remover(Produto p);
        IList<Produto> Produtos();

    }
}
