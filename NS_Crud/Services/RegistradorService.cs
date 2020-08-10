using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NS_Crud.Services
{
    public class RegistradorService : BackgroundService
    {
        private readonly RepositorioService repositorioService;
        private string json { get; set; }
        private bool carregado { get; set; }
        public RegistradorService ( RepositorioService _repositorioService ) { 
            repositorioService = _repositorioService;
        }

        public void primeiroCarregamento()
        {
            json = File.ReadAllText(Startup.caminhoBanco);
            RepositorioService repositorio = Newtonsoft.Json.JsonConvert.DeserializeObject<RepositorioService>(json);

            lock (repositorioService)
            {
                repositorioService.listaDeFilmes = repositorio.listaDeFilmes;
                repositorioService.listaDeClientes = repositorio.listaDeClientes;
                repositorioService.listaDeLocacoes = repositorio.listaDeLocacoes;
                // repositorioService.listaDeLocacoes = repositorio.listaDeLocacoes;
            }
            carregado = true;
        }


        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    if (carregado)
                    {
                        json = Newtonsoft.Json.JsonConvert.SerializeObject(repositorioService);
                        File.WriteAllText(Startup.caminhoBanco, json);
                        await Task.Delay(20000);
                    }
                    else
                    {
                        this.primeiroCarregamento();
                        
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro xd: " + ex.Message.ToString());
                    await Task.Delay(1000);
                }

                
            }
        }

    }

}
