using BibliotecaCore.Requests;
using BibliotecaCore.RegrasNegocio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BibliotecaCore.Entidades;

namespace BibliotecaApi.Controllers
{
    [Route("biblioteca/livro")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        public AplicacaoLivro _app { get; }

        public LivroController(AplicacaoLivro appLivro)
        {
            _app = appLivro;
        }

        [HttpGet]
        [Route("/id={id}")]
        public IActionResult getLivro([FromRoute] Guid id)
        {
            var livro = _app.GetLivro(id);
            return Ok(livro);
        }

        [HttpGet]
        [Route("/todosLivros")]
        public IActionResult getTodosLivros()
        {
            IEnumerable<Livro> todosLivros = _app.GetTodosLivros();

            return Ok(todosLivros);
        }

        [HttpPost]
        public IActionResult cadastraLivro([FromBody] LivroRequest livro)
        {
            _app.CadastrarLivro(livro);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult atualizaLivro([FromRoute] Guid id, LivroRequest livro)
        {
            var updateLivro = _app.AlterarLivro(id, livro);
            return Ok(updateLivro);
        }

        [HttpDelete("{id}")]
        public IActionResult removeLivro(Guid id)
        {
            _app.RemoverLivro(id);
            return NoContent();
        }
    }
}
