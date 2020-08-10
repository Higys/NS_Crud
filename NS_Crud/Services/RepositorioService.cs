using NS_Crud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NS_Crud.Services
{
    public class RepositorioService
    {
        public List<Filme> listaDeFilmes { get; set; } = new List<Filme>();
        public List<Cliente> listaDeClientes { get; set; } = new List<Cliente>();
        public List<Locacao> listaDeLocacoes { get; set; } = new List<Locacao>();
        // public List<LocacaoItem> listaDeLocacoeItem { get; set; } = new List<LocacaoItem>();
        public int proxIdFilme { get => listaDeFilmes.Count > 0 ? listaDeFilmes.Max(q => q.Id) + 1 : 1; }
        public int proxIdCliente { get => listaDeClientes.Count != 0 ? listaDeClientes.Max(q => q.Id) + 1 : 1; }
        public int proxIdLocacao { get => listaDeLocacoes.Count > 0 ? listaDeLocacoes.Max(q => q.Id) + 1 : 1; }

    }

}
