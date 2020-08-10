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
    public class FilmeController : Controller
    {
        private readonly IFilmeService filmeService;
        public FilmeController(IFilmeService _filmeService) { filmeService = _filmeService; }
        
        public IActionResult Index()
        {
            return View(filmeService.getFilmes());
        }
        [Route("Filmes")]
        [HttpGet]
        public IList<Filme> Get()
        {
            return filmeService.getFilmes();
        }

        [HttpGet("{id}")]
        public Filme Get(int id)
        {
            return filmeService.getFilmeDetalhe(id);
        }

        [Route("[action]")]
        public IActionResult Detalhes(int id)
        {
            Filme filme = filmeService.getFilmeDetalhe(id);
            return View(filme);
        }

        // Rotas de adicionar novo filme
        [Route("[action]")]
        public IActionResult Adicionar()
        {
            return View();
        }

        [Route("[action]")]
        public IActionResult AdicionarFilme([Bind] Filme filme)
        {
            if (ModelState.IsValid)
            {
                filmeService.addFilme(filme);
                return RedirectToAction("Index");
            }
            return View(filme);
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] Filme filme)
        {
            try
            {
                filmeService.addFilme(filme);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message.ToString());
                return BadRequest();
            }

        }

        // Rotas para edição de Filmes

        [Route("[action]")]
        public IActionResult Editar(int id)
        {
            Filme filme = filmeService.getFilmeDetalhe(id);
            return View(filme);
        }

        [Route("[action]")]
        public IActionResult EditarFilme([Bind] Filme filme)
        {
            if (ModelState.IsValid)
            {
                filmeService.editFilme(filme, filme.Id);
                return RedirectToAction("Index");
            }

            return View(filme);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Filme filme)
        {
            try
            {
                filmeService.editFilme(filme, id);
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
        public IActionResult Delete([Bind] int id)
        {
            try
            {
                filmeService.delFilme(id);
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
            Filme filme = filmeService.getFilmeDetalhe(id);
            return View(filme);
        }


    }
}
