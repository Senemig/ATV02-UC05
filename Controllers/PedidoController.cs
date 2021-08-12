using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Atividade2.Models;

namespace Atividade2.Controllers
{
    //Controller para itens de classe Pedido
    public class PedidoController :Controller
    {
        //Recebe como parâmetro o número do pedido selecionado na Lista exibida
        //e então exibe o pedido, listando seus itens
        public IActionResult ExibirPedido(int i)
        {
            List<Pedido> pedidos = ListaPedidos.ListarPedidos();
            List<Item> lista = pedidos[i].ListarItens();
            return View("Pedido", pedidos[i]);
        }
        
        //Recebe o número do pedido selecionado como parâmetro, gera um novo item em branco
        //e então retorna a View para cadastro do item (Form), passando o próprio item como parâmetro
        //para 'carregar'' o número do Pedido para a próxima etapa  
        public IActionResult CadastrarItem(int i)
        {
            Item item = new Item();
            item.itemPedido = i+1;
            return View("AdicionarItem", item);
        }

        //Recebe o Item cadastrado no Form e o inclui à lista de Itens do pedido selecionado
        public IActionResult IncluirItem(Item i)
        {
            int IndexPedido = i.itemPedido - 1;
            List<Pedido> lista = ListaPedidos.ListarPedidos();
            lista[IndexPedido].AdicionarItem(i);
            return View("Pedido", lista[IndexPedido]);
        }

        //Recebe o índice do Pedido selecionado e o Item a ser removido como parâmetro e o remove da lista
        //de itens do Pedido selecionado, retornando a View do Pedido com a lista de Itens atualizada
        public IActionResult RemoverItem(int p, int i)
        {
            int IndexPedido = p;
            List<Pedido> lista = ListaPedidos.ListarPedidos();
            lista[IndexPedido].DeletarItem(i);
            return View("Pedido", lista[IndexPedido]);
        }

        //Recebe o índice do Pedido selecionado como parâmetro, lista os Pedidos na ListaPedidos
        //e então retorna a função FinalizarPedido passando o Pedido selecionado como parâmetro
        public IActionResult FinalizarPedido(int p)
        {
            int IndexPedido = p;
            List<Pedido> pedidos = ListaPedidos.ListarPedidos();
            return View("FinalizarPedido", pedidos[p]);
        }
    }
}