using BibliotecaCore.Entidades;
using BibliotecaCore.RegrasNegocio;
using BibliotecaCore.Requests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaApi.Controllers
{
    [Route("biblioteca/autor")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private AplicacaoAutor _app { get; }

        public AutorController(AplicacaoAutor app)
        {
            _app = app;
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult getAutor([FromRoute] Guid id)
        {
            var autor = _app.GetAutor(id);
            return Ok(autor);
        }

        [HttpGet]
        [Route("todosAutores")]
        public IActionResult getTodosAutores()
        {
            IEnumerable<Autor> todosAutores = _app.GetTodosLivros();
            return Ok(todosAutores);
        }

        [HttpPost]
        public IActionResult cadastraAutor([FromBody] AutorRequest autor)
        {
            _app.CadastrarAutor(autor);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult atualizaAutor([FromRoute]Guid id, AutorRequest autor)
        {
            var updateAutor = _app.AlterarAutor(id, autor);
            return Ok(updateAutor);
        }

        [HttpDelete("{id}")]
        public IActionResult removeAutor(Guid id)
        {
            _app.RemoverAutor(id);
            return NoContent();
        }
    }
}
