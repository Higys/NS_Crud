using NS_Crud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NS_Crud.Services
{
    public class ClienteService : IClienteService
    {

        private readonly RepositorioService repositorioService;
        public ClienteService(RepositorioService _repositorioService) { repositorioService = _repositorioService; }

        public List<Cliente> getClientes()
        {
            lock (repositorioService.listaDeClientes)
            {
                return repositorioService.listaDeClientes;
            }
        }

        public Cliente getClienteDetalhe(int id)
        {
            lock (repositorioService.listaDeClientes)
            {
                return repositorioService.listaDeClientes.Find(x => x.Id == id);
            }
        }

        public bool addCliente(Cliente cliente)
        {
            lock (repositorioService.listaDeClientes)
            {
                cliente.Id = repositorioService.proxIdCliente;
                repositorioService.listaDeClientes.Add(cliente);
                return true;
            }
        }

        public bool editCliente(Cliente cliente, int id)
        {
            lock (repositorioService.listaDeClientes)
            {
                Cliente clienteRegistrado = cliente;
                clienteRegistrado.Id = id;
                int indice = repositorioService.listaDeClientes.FindIndex(x => x.Id == id);
                repositorioService.listaDeClientes.RemoveAt(indice);
                addCliente(clienteRegistrado);
                return true;
            }
        }

        public bool delCliente(int id)
        {
            lock (repositorioService.listaDeClientes)
            {
                int indice = repositorioService.listaDeClientes.FindIndex(x => x.Id == id);
                repositorioService.listaDeClientes.RemoveAt(indice);
                return true;
            }
        }


    }

    public interface IClienteService 
    {
        List<Cliente> getClientes();
        Cliente getClienteDetalhe(int id);
        bool addCliente(Cliente cliente);
        bool delCliente(int id);
        bool editCliente(Cliente cliente, int id);
    }
}
