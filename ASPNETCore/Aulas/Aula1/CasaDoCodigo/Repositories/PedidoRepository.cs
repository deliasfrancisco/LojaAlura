using CasaDoCodigo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
	public interface IPedidoRepository
	{
		Pedido GetPedido();
		void AddItem(string codigo);
	}

	public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {
		private readonly IHttpContextAccessor contextAccessor; 

        public PedidoRepository(ApplicationContext contexto,
			IHttpContextAccessor contextAccessor) : base(contexto)
        {
			this.contextAccessor = contextAccessor;
        }

		public void AddItem(string codigo)
		{
			var produto = contexto.Set<Produto>()
                .Where(p => p.Codigo == codigo)
                .SingleOrDefault(); //obtendo o produto

			if (produto == null)
			{
				throw new ArgumentException("Produto não encontrado"); // lançando uma exceção de produto nulo
			}

			var pedido = GetPedido();  //adicionando pedido

			var itemPedido = contexto.Set<ItemPedido>() 
				.Where(i => i.Produto.Codigo== codigo 
                && i.Pedido.Id == pedido.Id)
						.SingleOrDefault();// verificar se o pedido ja existe

            if (itemPedido == null)
			{
				itemPedido = new ItemPedido(pedido, produto, 1, produto.Preco); // se o pedido não existir vai ser criado uma pedido passando por parametro os dados de um pedido
				contexto.Set<ItemPedido>()
								.Add(itemPedido); //adicionando

				contexto.SaveChanges(); //salvando no banco
			}
		}

		public Pedido GetPedido()
		{
			var pedidoId = GetPedidoId(); //pegar (obter) o id gravado na sessão
			var pedido = dbSet
                .Include(p => p.Itens)
                .ThenInclude(i => i.Produto)
				.Where(p => p.Id == pedidoId)
                .SingleOrDefault(); // SingleOrDefault -> se o pedidoId atender a solicitação feita na lambda ele retorna true, senão ele retorna null

            if (pedido == null) //verificando se o pedido é nulo
			{
				pedido = new Pedido();
				dbSet.Add(pedido);
				contexto.SaveChanges();
				SetPedidoId(pedido.Id); // grava no http context
			}

			return pedido;
		}

		private int? GetPedidoId() // o ? informa que o id pode ser nulo
		{
			return contextAccessor.HttpContext.Session.GetInt32("pedidoId"); //pegando o objeto da sessão
		}

		private void SetPedidoId(int pedidoId) //gravar o pedidoId na sessão
		{
			contextAccessor.HttpContext.Session.SetInt32("pedidoId", pedidoId);
		}

    }
}
