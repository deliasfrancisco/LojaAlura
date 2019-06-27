using CasaDoCodigo.Models;
using CasaDoCodigo.Models.ViewModels;
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
        Task<Pedido> GetPedido();
        Task AddItem(string codigo);
        Task<UpdateQuantidadeResponse> UpdateQuantidade(ItemPedido itemPedido);
        Task<Pedido> UpdateCadastro(Cadastro cadastro); //metodos criados na interface que são implementados na propria classe
    }

    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {
        private readonly IHttpContextAccessor contextAccessor;
        private readonly IItemPedidoRepository itemPedidoRepository;
        private readonly ICadastroRepository cadastroRepository; // referencias

        public PedidoRepository(ApplicationContext contexto,
            IHttpContextAccessor contextAccessor,
            IItemPedidoRepository itemPedidoRepository,
            ICadastroRepository cadastroRepository) : base(contexto)
        {
            this.contextAccessor = contextAccessor;
            this.itemPedidoRepository = itemPedidoRepository;
            this.cadastroRepository = cadastroRepository;
        }

        public async Task AddItem(string codigo)
        {
            var produto = await contexto.Set<Produto>()
                            .Where(p => p.Codigo == codigo)
                            .SingleOrDefaultAsync(); //obtendo o produto

            if (produto == null)
            {
                throw new ArgumentException("Produto não encontrado"); //tratando a exceção
            }

            var pedido = await GetPedido();

            var itemPedido = await contexto.Set<ItemPedido>()
                                .Where(i => i.Produto.Codigo == codigo
                                        && i.Pedido.Id == pedido.Id)
                                .SingleOrDefaultAsync();

            if (itemPedido == null)
            {
                itemPedido = new ItemPedido(pedido, produto, 1, produto.Preco); ; // se o pedido não existir vai ser criado uma pedido passando por parametro os dados de um pedido

                await contexto.Set<ItemPedido>()
                    .AddAsync(itemPedido); //adicionando

                await contexto.SaveChangesAsync();
            }
        }

        public async Task<Pedido> GetPedido()
        {
            var pedidoId = GetPedidoId(); //obter o pedido da sessão
            var pedido =  //consulta link que vai retornar o pedido
                await dbSet
                .Include(p => p.Itens)
                    .ThenInclude(i => i.Produto)
                .Include(p => p.Cadastro) //traz tambem os dados do cadastro
                .Where(p => p.Id == pedidoId)
                .SingleOrDefaultAsync(); // SingleOrDefault -> se o pedidoId atender a solicitação feita na lambda ele retorna true, senão ele retorna null

            if (pedido == null)
            {
                pedido = new Pedido();
                dbSet.Add(pedido);
                await contexto.SaveChangesAsync();
                SetPedidoId(pedido.Id);// grava o http context
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

        public async Task<UpdateQuantidadeResponse> UpdateQuantidade(ItemPedido itemPedido)
        {
            var itemPedidoDB = await itemPedidoRepository.GetItemPedido(itemPedido.Id);

            if (itemPedidoDB != null)
            {
                itemPedidoDB.AtualizaQuantidade(itemPedido.Quantidade);

                if (itemPedido.Quantidade == 0)
                {
                    await itemPedidoRepository.RemoveItemPedido(itemPedido.Id);
                }

                await contexto.SaveChangesAsync();

                var pedido = await GetPedido();
                var carrinhoViewModel = new CarrinhoViewModel(pedido.Itens);

                return new UpdateQuantidadeResponse(itemPedidoDB, carrinhoViewModel);
            }

            throw new ArgumentException("ItemPedido não encontrado");
        }

        public async Task<Pedido> UpdateCadastro(Cadastro cadastro)
        {
            var pedido = await GetPedido();
            await cadastroRepository.Update(pedido.Cadastro.Id, cadastro);
            return pedido;
        }
    }
}
