using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaCore.Entidades;
using BibliotecaCore.IRepositorios;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaInfra.EntityFramework.Repositorios
{
    public class RepositorioAutor : IRepositorioAutor
    {
        private BancoDeDados _BancoDeDados  { get; }

        public RepositorioAutor(BancoDeDados bancoDeDados)
        {
            _BancoDeDados = bancoDeDados;
        }

        public void AlterarAutor(Autor autor)
        {
            _BancoDeDados.Autor.Update(autor);
            _BancoDeDados.SaveChanges();
        }

        public Autor GetAutor(Guid id)
        {
            var autor = _BancoDeDados.Autor.Find(id);
            var listaLivros = _BancoDeDados.LivroAutores.Where(l => l.AutorId == autor.Id).Include(p => p.Livro);
            autor.Livros.AddRange(listaLivros);

            return autor;
        }

        public List<Autor> GetTodosAutores()
        {
            var todosAutores = _BancoDeDados.Autor.AsNoTracking().ToList();

            foreach (var autor in todosAutores)
            {
                var listaLivros = _BancoDeDados.LivroAutores.Where(l => l.AutorId == autor.Id).Include(p => p.Livro);
                autor.Livros.AddRange(listaLivros);
            }

            return todosAutores;
        }

        public void RemoveAutor(Autor autor)
        {
            _BancoDeDados.Autor.Remove(autor);
            _BancoDeDados.SaveChanges();
        }

        public void Salvar(Autor autor)
        {
            _BancoDeDados.Autor.Add(autor);
            _BancoDeDados.SaveChanges();
        }
    }
}
