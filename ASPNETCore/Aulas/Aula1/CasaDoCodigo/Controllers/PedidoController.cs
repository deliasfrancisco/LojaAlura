using CasaDoCodigo.Models;
using CasaDoCodigo.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Controllers
{
	public class PedidoController : Controller
	{
		private readonly IProdutoRepository produtoRepository;
		private readonly IPedidoRepository pedidoRepository;

		public PedidoController(IProdutoRepository produtoRepository,
			IPedidoRepository pedidoRepository)
		{
			this.produtoRepository = produtoRepository;
			this.pedidoRepository = pedidoRepository;
		}

		public IActionResult Carrossel()
		{
			return View(produtoRepository.GetProdutos());//passando a listagem de produtos para o controller
		}

		public IActionResult Carrinho(string codigo)
		{
			if (!string.IsNullOrEmpty(codigo)) //verifica se o codigo foi preenchido ou não
			{
				pedidoRepository.AddItem(codigo);
			}

			Pedido pedido = pedidoRepository.GetPedido(); //metodo para receber o pedido da sessão atual
			return View(pedido.Itens); // passando (retornando) para a view a solicitação de itens feita no repositorio
		}

		public IActionResult Cadastro()
		{
			return View();
		}

		public IActionResult Resumo()
		{
            Pedido pedido = pedidoRepository.GetPedido(); //consultyando o pedido

			return View(pedido);
		}

        [HttpPost] //com o http post força os parametros a serem passados pelo corpo da pagina HTML, impedindo que os dados sejam passados pelo endereço do navagador
        public void UpdateUnidade([FromBody]ItemPedido itemPedido) //metodo para ser utilizado no javascript
        {

        }
	}
}
