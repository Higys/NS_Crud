using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NS_Crud.Models
{
    public class Filme
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public int Qtd_Copias { get; set; }
        public int Qtd_Disponiveis { get; set; }
        public double ValorLocacao { get; set; }
    }

}
