using NS_Crud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NS_Crud.Services
{
    public class FilmeService : IFilmeService
    {
        private readonly RepositorioService repositorioService;
        
        public FilmeService (RepositorioService _repositorioService ) { repositorioService = _repositorioService; }
        public List<Filme> getFilmes()
        {
            lock(repositorioService.listaDeFilmes)
            {
                return repositorioService.listaDeFilmes;
            }
            
        }

        public Filme getFilmeDetalhe(int id)
        {
            lock (repositorioService.listaDeFilmes)
            {
                return repositorioService.listaDeFilmes.Find(x => x.Id == id);
            }
        }

        public bool addFilme(Filme filme)
        {
            lock (repositorioService.listaDeFilmes)
            {
                filme.Id = repositorioService.proxIdFilme;
                repositorioService.listaDeFilmes.Add(filme);
                return true;
            }

        }
        public bool editFilme(Filme filme, int id)
        {
            lock (repositorioService.listaDeFilmes)
            {
                Filme filmeRegistrado = filme;
                filmeRegistrado.Id = id;
                int indice = repositorioService.listaDeFilmes.FindIndex(x => x.Id == id);
                repositorioService.listaDeFilmes.RemoveAt(indice);
                addFilme(filmeRegistrado);
                return true;

            }
        }

        public bool delFilme(int id)
        {
            lock (repositorioService.listaDeFilmes)
            {
                int indice = repositorioService.listaDeFilmes.FindIndex(x => x.Id == id);
                repositorioService.listaDeFilmes.RemoveAt(indice);
                return true;
            }
        }


    }

    public interface IFilmeService
    {
        List<Filme> getFilmes();
        Filme getFilmeDetalhe(int id);
        bool addFilme(Filme filme);
        bool delFilme(int id);
        bool editFilme(Filme filme, int id);
    }
}
