using CasaDoCodigo.Models;
using CasaDoCodigo.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Migrations
{
	public class UpdateQuantidadeResponse
	{
		public UpdateQuantidadeResponse(ItemPedido itemPedido, CarrinhoViewModel carrinhoViewModel)
		{
			ItemPedido = itemPedido;
			CarrinhoViewModel = carrinhoViewModel;
		}

		public ItemPedido ItemPedido { get; } //somente leitura
		public CarrinhoViewModel CarrinhoViewModel { get; } //somente leitura
	}
}
