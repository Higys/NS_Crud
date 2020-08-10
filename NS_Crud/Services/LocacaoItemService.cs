using NS_Crud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NS_Crud.Services
{
    public class LocacaoItemService
    {
        private readonly RepositorioService repositorioService;

        public LocacaoItemService(RepositorioService _repositorioService) { repositorioService = _repositorioService; }

        public List<LocacaoItem> getLocacaoLista(int id)
        {
            return repositorioService.listaDeLocacoes.ElementAt(id).ListaLocacao;
        }

        public List<LocacaoItem> addLocacaoItem(List<LocacaoItem> listaLocacao, int id)
        {
            List<LocacaoItem> listaLocacaoItens = new List<LocacaoItem>();

            lock (repositorioService.listaDeLocacoes)
            {
                foreach (var item in listaLocacao)
                {
                    item.IdLocacao = id;
                    item.Filme = repositorioService.listaDeFilmes.Find(x => x.Id == item.IdFilme);
                    repositorioService.listaDeFilmes.Find(x => x.Id == item.IdFilme).Qtd_Disponiveis--;

                    listaLocacaoItens.Add(item);
                }
                return listaLocacaoItens;
            }
        }


    }
}
