using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Models.ViewModels
{
	public class CarrinhoViewModel
	{
		public CarrinhoViewModel(IList<ItemPedido> itens)
		{
			Itens = itens;
		}

		public IList<ItemPedido> Itens { get; } //só vai ter o get pois o metodo é somente para leitura

		public decimal Total => Itens.Sum(i => i.Quantidade * i.PrecoUnitario);
	}
}
