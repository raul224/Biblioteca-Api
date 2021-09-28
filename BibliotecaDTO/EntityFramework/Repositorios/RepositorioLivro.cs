using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaCore.Entidades;
using BibliotecaCore.IRepositorios;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaInfra.EntityFramework
{
    public partial class RepositorioLivro : IRepositorioLivro
    {
        public BancoDeDados bancoDeDados { get; }
        public RepositorioLivro(BancoDeDados bancoDeDados)
        {
            this.bancoDeDados = bancoDeDados;
        }

        public void Salvar(Livro livro)
        {
            bancoDeDados.Livro.Add(livro);
            bancoDeDados.SaveChanges();
        }

        public Livro GetLivro(Guid id)
        {
            var livro = bancoDeDados.Livro.Find(id);
            var listaAutores = bancoDeDados.LivroAutores.Where(l => l.LivroId == livro.Id).Include(p => p.Autor);
            livro.Autores.AddRange(listaAutores);

            return livro;
        }
        public List<Livro> GetTodosLivros()
        {
            List<Livro> todosLivros = bancoDeDados.Livro.AsNoTracking().ToList();

            foreach(var livro in todosLivros)
            {
                var listaAutores = bancoDeDados.LivroAutores.Where(l => l.LivroId == livro.Id).Include(p => p.Autor);
                livro.Autores.AddRange(listaAutores);
            }

            return todosLivros;
        }
        public void AlterarLivro(Livro livro)
        {
            bancoDeDados.Livro.Update(livro);
            bancoDeDados.SaveChanges();

        }
        public void RemoveLivro(Livro livro)
        {
            bancoDeDados.Livro.Remove(livro);
            bancoDeDados.SaveChanges();
        }
    }
}
