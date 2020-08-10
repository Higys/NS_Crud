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
    public class LocacaoController : Controller
    {
        private readonly ILocacaoService locacaoService;
        public LocacaoController(ILocacaoService _locacaoService) { locacaoService = _locacaoService; }
        public IActionResult Index()
        {
            return View(locacaoService.getLocacao());
        }
        [Route("Locacoes")]
        [HttpGet]
        public IList<Locacao> Get()
        {
            return locacaoService.getLocacao();
        }

        [HttpGet("{id}")]
        public Locacao Get(int id)
        {
            return locacaoService.getLocacaoDetalhe(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Locacao locacao)
        {
            try
            {
                locacaoService.addLocacao(locacao);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message.ToString());
                return BadRequest();
            }

        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Locacao locacao, int id)
        {
            try
            {
                locacaoService.editLocacao(locacao, id);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message.ToString());
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        [Route("[action]")]
        public IActionResult Delete(int id)
        {
            try
            {
                locacaoService.delLocacao(id);
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
            Locacao locacao = locacaoService.getLocacaoDetalhe(id);
            return View(locacao);
        }









    }
}