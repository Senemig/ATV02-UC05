using System.Collections.Generic;

namespace Atividade2.Models
{
    public class Pedido
    {
        public List<Item> ListaItens = new List<Item>();

        public double ValorTotal = 0;
        public int QtdItens = 0;
        public int nPedido;//Número do Pedido-pai do Item

        public void AdicionarItem(Item i)
        {
            ListaItens.Add(i);
            QtdItens++;
            ValorTotal += (i.Valor * i.Quantidade);
        }

        public void DeletarItem(int i)
        {
            QtdItens--;
            ValorTotal -= (ListaItens[i].Valor * ListaItens[i].Quantidade);
            ListaItens.RemoveAt(i);
        }

        public List<Item> ListarItens()
        {
            return ListaItens;
        }
    }
}