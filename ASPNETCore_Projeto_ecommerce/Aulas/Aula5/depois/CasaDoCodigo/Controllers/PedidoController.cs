using CasaDoCodigo.Models;
using CasaDoCodigo.Models.ViewModels;
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
        private readonly IItemPedidoRepository itemPedidoRepository;

        public PedidoController(IProdutoRepository produtoRepository,
            IPedidoRepository pedidoRepository,
            IItemPedidoRepository itemPedidoRepository)
        {
            this.produtoRepository = produtoRepository;
            this.pedidoRepository = pedidoRepository;
            this.itemPedidoRepository = itemPedidoRepository;
        }

        public async Task<IActionResult> Carrossel()
        {
            return View(await produtoRepository.GetProdutos()); //passando a listagem de produtos para o controller
        }

        public async Task<IActionResult> Carrinho(string codigo)
        {
            if (!string.IsNullOrEmpty(codigo)) //verifica se o codigo foi preenchido ou não
            {
                await pedidoRepository.AddItem(codigo);
            }

            Pedido pedido = await pedidoRepository.GetPedido(); //metodo para receber o pedido da sessão atual
            List<ItemPedido> itens = pedido.Itens;
            CarrinhoViewModel carrinhoViewModel = new CarrinhoViewModel(itens);
            return base.View(carrinhoViewModel);  // passando (retornando) para a view a solicitação de itens feita no repositorio
        }

        public async Task<IActionResult> Cadastro()
        {
            var pedido = await pedidoRepository.GetPedido();

            if (pedido == null)
            {
                return RedirectToAction("Carrossel");   //redirecionando para a action de carrossel caso o pedido seja nulo para  que assim haja um pedido
            }

            return View(pedido.Cadastro);
        }

        [HttpPost] //restringe o acesso pelo browser
        [ValidateAntiForgeryToken]  //valida o token na hora de receber a chave de token, protege de acesso externo
        public async Task<IActionResult> Resumo(Cadastro cadastro)
        {
            if (ModelState.IsValid) //varificando se o model cadastro é valido
            {
                return View(await pedidoRepository.UpdateCadastro(cadastro));
            }
            return RedirectToAction("Cadastro"); //caso o model não seja valido é redirecionado para a view cadastro
        }

        [HttpPost]//com o http post força os parametros a serem passados pelo corpo da pagina HTML, impedindo que os dados sejam passados pelo endereço do navagador
        [ValidateAntiForgeryToken] // protegendo contra acesso externo
        public async Task<UpdateQuantidadeResponse> UpdateQuantidade([FromBody]ItemPedido itemPedido)
        {
            return await pedidoRepository.UpdateQuantidade(itemPedido);
        }
    }
}
