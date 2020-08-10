using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NS_Crud.Models
{
    public class LocacaoItem
    {
        public int IdFilme { get; set; }
        public int IdLocacao { get; set; }
        public Filme Filme { get; set; } // todo popular filme a partir do IdFilme
        public DateTime DataLocacao { get; set; }
        public DateTime DataDevolucao { get; set; }
        public double ValorMultaPorDia { get; set; }
        public double ValorLocacao { get; set; }
        public double ValorTotalMultaItem { 
            get
            {
                if(DateTime.Today > DataDevolucao)
                {
                    var difData = DateTime.Today - DataDevolucao;
                    double total = difData.Days * ValorMultaPorDia;
                    return total;
                }
                else
                {
                    return 0;
                }

            } 
        }
    }
}
