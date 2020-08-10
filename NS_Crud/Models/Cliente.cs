using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NS_Crud.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public int Idade { get; set; }
        public string Cpf { get; set; }

    }
}
