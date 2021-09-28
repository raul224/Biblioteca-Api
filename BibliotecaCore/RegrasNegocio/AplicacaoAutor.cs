using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaCore.Entidades;
using BibliotecaCore.IRepositorios;
using BibliotecaCore.Requests;

namespace BibliotecaCore.RegrasNegocio
{
    public class AplicacaoAutor
    {
        private IRepositorioAutor _repositorioAutor { get; }

        public AplicacaoAutor(IRepositorioAutor repositorioAutor)
        {
            _repositorioAutor = repositorioAutor;
        }

        public Autor GetAutor(Guid id)
        {
            var autor = _repositorioAutor.GetAutor(id);
            return autor;
        }

        public IEnumerable<Autor> GetTodosLivros()
        {
            IEnumerable<Autor> TodosAutores = _repositorioAutor.GetTodosAutores();
            return TodosAutores;
        }

        public void CadastrarAutor(AutorRequest autorCadastro)
        {
            var autor = new Autor();
            autor.Nome = autorCadastro.nome;
            autor.SobreNome = autorCadastro.sobreNome;
            autor.DataNascimento = autorCadastro.dataNascimento;
            autor.Email = autorCadastro.email;

            _repositorioAutor.Salvar(autor);
        }

        public Autor AlterarAutor(Guid id, AutorRequest autorAlterar)
        {
            var autor = _repositorioAutor.GetAutor(id);

            autor.Nome = autorAlterar.nome;
            autor.SobreNome = autorAlterar.sobreNome;
            autor.DataNascimento = autorAlterar.dataNascimento;
            autor.Email = autorAlterar.email;

            _repositorioAutor.AlterarAutor(autor);
            return autor;
        }

        public void RemoverAutor(Guid id)
        {
            var autor = _repositorioAutor.GetAutor(id);
            _repositorioAutor.RemoveAutor(autor);
        }
    }
}
