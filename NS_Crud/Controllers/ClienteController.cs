using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NS_Crud.Models;
using NS_Crud.Services;

namespace NS_Crud.Controllers
{
    
    [Route("[controller]")]
    public class ClienteController : Controller
    {
        private readonly IClienteService clienteService;
        public ClienteController(IClienteService _clienteService) { clienteService = _clienteService; }
        
   
        public IActionResult Index()
        {
            return View(clienteService.getClientes());
        }
        [Route("Clientes")]
        [HttpGet]
        public IList<Cliente> Get()
        {
            return clienteService.getClientes();
        }

        [HttpGet("{id}")]
        public Cliente Get(int id)
        {
            return clienteService.getClienteDetalhe(id);
        }

        [Route("[action]")]
        public IActionResult Detalhes(int id)
        {
            Cliente cliente = clienteService.getClienteDetalhe(id);
            return View(cliente);
        }

        [Route("[action]")]
        public IActionResult Adicionar()
        {
            return View();
        }

        [Route("[action]")]
        public IActionResult AdicionarCliente([Bind] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                clienteService.addCliente(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Cliente cliente)
        {
            try
            {
                clienteService.addCliente(cliente);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message.ToString());
                return BadRequest();
            }

        }

        [Route("[action]")]
        public IActionResult Editar(int id)
        {
            Cliente cliente = clienteService.getClienteDetalhe(id);
            return View(cliente);
        }
        
        [Route("[action]")]
        public IActionResult EditarCliente([Bind] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                clienteService.editCliente(cliente, cliente.Id);
                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        [HttpPut("{id}")]
        public bool Put([FromBody] Cliente cliente, int id)
        {
            try
            {
                return clienteService.editCliente(cliente, id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message.ToString());
                return false;
            }
        }


        [HttpDelete("{id}")]
        [Route("[action]")]
        public IActionResult Delete([Bind] int id)
        {
            try
            {
                clienteService.delCliente(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message.ToString());
                return RedirectToAction("Index");
            }
        }

        [Route("[action]")]
        public IActionResult Deletar(int id)
        {
            Cliente cliente = clienteService.getClienteDetalhe(id);
            return View(cliente);
        }




    }

}