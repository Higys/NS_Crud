using NS_Crud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NS_Crud.Services
{
    public class LocacaoService : ILocacaoService
    {
        private readonly RepositorioService repositorioService;
        private readonly LocacaoItemService locacaoItemService;
        public LocacaoService(RepositorioService _repositorioService, LocacaoItemService _locacaoItemService)
        {
            repositorioService = _repositorioService;
            locacaoItemService = _locacaoItemService;
        }

        public List<Locacao> getLocacao()
        {
            lock (repositorioService.listaDeLocacoes)
            {
                return repositorioService.listaDeLocacoes;
            }
        }
        public Locacao getLocacaoDetalhe(int id)
        {
            lock (repositorioService.listaDeLocacoes)
            {
                return repositorioService.listaDeLocacoes.Find(x => x.Id == id);
            }
        }


        public bool addLocacao(Locacao locacao)
        {
            lock (repositorioService.listaDeLocacoes)
            {
                locacao.Id = repositorioService.proxIdLocacao;
                locacao.Cliente = repositorioService.listaDeClientes.Find(x => x.Id == locacao.IdCliente);

                locacao.ListaLocacao = locacaoItemService.addLocacaoItem(locacao.ListaLocacao, locacao.Id);

                repositorioService.listaDeLocacoes.Add(locacao);
                return true;
            }
        }
        public bool editLocacao(Locacao locacao, int id)
        {
            lock (repositorioService.listaDeLocacoes)
            {
                Locacao locacaoRegistrada = locacao;
                locacao.Id = id;
                int indice = repositorioService.listaDeLocacoes.FindIndex(x => x.Id == id);
                repositorioService.listaDeLocacoes.RemoveAt(indice);
                addLocacao(locacaoRegistrada);
                return true;
            }
        }

        public bool delLocacao(int id)
        {
            lock (repositorioService.listaDeLocacoes)
            {
                int indice = repositorioService.listaDeLocacoes.FindIndex(x => x.Id == id);
                repositorioService.listaDeLocacoes.RemoveAt(indice);

                return true;
            }
        }
    }

    public interface ILocacaoService
        {
            List<Locacao> getLocacao();
            Locacao getLocacaoDetalhe(int id);
            bool addLocacao(Locacao locacao);
            bool delLocacao(int id);
            bool editLocacao(Locacao locacao, int id);

        }
}
