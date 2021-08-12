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
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //Exibe a lista de itens
        public IActionResult Index()
        {
            List<Pedido> pedidos = ListaPedidos.ListarPedidos();
            return View(pedidos);
        }

        //Cria um pedido em branco, usa pedidos.Count() para salvar o número do pedido e então inclui o
        //pedido na Lista de Pedidos
        public IActionResult CriarPedido()
        {
            List<Pedido> pedidos = ListaPedidos.ListarPedidos();

            Pedido p = new Pedido();
            if(pedidos.Count() > 0){p.nPedido = pedidos.Count();}    
            else{p.nPedido = 0;}                    
            ListaPedidos.Incluir(p);

            return View("Index", pedidos);
        }

        
        //Recebe como parâmetro o número do pedido selecionado na Lista exibida
        //e então o remove da Lista de Pedidos. Depois é feita uma atualização
        //dos números de cada pedido
        public IActionResult DeletarPedido(int i)
        {
            List<Pedido> pedidos = ListaPedidos.ListarPedidos();

            pedidos.RemoveAt(i);
            for(int x = 0; x < pedidos.Count(); x++)
            {
                if(pedidos[x].nPedido != x)
                {
                    pedidos[x].nPedido = x;
                }
            }
            return View("Index", pedidos);
        }

    }
}
