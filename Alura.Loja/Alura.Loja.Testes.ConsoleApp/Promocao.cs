using System;
using System.Collections.Generic;

namespace Alura.Loja.Testes.ConsoleApp
{
    public class Promocao
    {
        public int Id { get; set; }
        public string Descricao { get; internal set; }
        public DateTime DataFim { get; internal set; }
        public DateTime DataInicio { get; internal set; }
        public IList<PromocaoProduto> Produto { get; internal set; }

        public override string ToString()
        {
            return $"Promoção: {this.Id}, {this.Descricao}, {this.DataInicio}, {this.DataFim}, {this.Produto}";
        }
    }
}
