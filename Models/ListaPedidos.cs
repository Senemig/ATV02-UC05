using System.Collections.Generic;

namespace Atividade2.Models
{
    public static class ListaPedidos
    {
        private static List<Pedido> pedidos = new List<Pedido>();

        public static void Incluir(Pedido p)
        {
            pedidos.Add(p);
        }

        public static List<Pedido> ListarPedidos()
        {
            return pedidos;
        }
    }
}