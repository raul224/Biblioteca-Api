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
    public class AplicacaoLivro
    {
        private IRepositorioLivro _RepositorioLivro { get; }
        public AplicacaoLivro(IRepositorioLivro RepositorioLivro)
        {
            _RepositorioLivro = RepositorioLivro;
        }

        public Livro GetLivro(Guid id)
        {
            Livro livro = _RepositorioLivro.GetLivro(id);
            return livro;
        }

        public IEnumerable<Livro> GetTodosLivros()
        {
            List<Livro> TodosLivros = _RepositorioLivro.GetTodosLivros();
            return TodosLivros;
        }

        public void CadastrarLivro(LivroRequest livroCadastro)
        {
            var criarLivro = new Livro
            {
                Id = new Guid(),
                Titulo = livroCadastro.Titulo,
                ISBN = livroCadastro.ISBN,
                DataPublicacao = livroCadastro.DataPublicacao
            };

            var ids = livroCadastro.Autores;

            foreach (var id in ids)
            {
                LivroAutor livroAutor = new LivroAutor();
                livroAutor.LivroId = criarLivro.Id;
                livroAutor.AutorId = id;

                criarLivro.Autores.Add(livroAutor);
            }

            _RepositorioLivro.Salvar(criarLivro);
        }

        public Livro AlterarLivro(Guid id, LivroRequest livroAlterar)
        {
            var livro = _RepositorioLivro.GetLivro(id);

            livro.Titulo = livroAlterar.Titulo;
            livro.ISBN = livroAlterar.ISBN;
            livro.DataPublicacao = livroAlterar.DataPublicacao;

            livro.Autores.Clear();

            var ids = livroAlterar.Autores;

            foreach (var idAutror in ids)
            {
                LivroAutor livroAutor = new LivroAutor();
                livroAutor.LivroId = livro.Id;
                livroAutor.AutorId = idAutror;

                livro.Autores.Add(livroAutor);
            }

            _RepositorioLivro.AlterarLivro(livro);
            return livro;
        }

        public void RemoverLivro(Guid id)
        {
            var livro = _RepositorioLivro.GetLivro(id);
            _RepositorioLivro.RemoveLivro(livro);
        }
    }
}
