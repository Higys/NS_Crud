using NS_Crud.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NS_Crud.Models
{
    public class Locacao
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public Cliente Cliente { get; set; }
        public List<LocacaoItem> ListaLocacao { get; set; } = new List<LocacaoItem>();
        public double ValorTotalLocacao { get => ListaLocacao.Sum(q => q.ValorLocacao); }
        public double ValorTotalMulta { get => ListaLocacao.Sum(q => q.ValorTotalMultaItem);}
    }
}
