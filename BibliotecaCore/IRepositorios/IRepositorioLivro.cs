using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaCore.Entidades;

namespace BibliotecaCore.IRepositorios
{
    public interface IRepositorioLivro
    {
        public void Salvar(Livro livro);
        public Livro GetLivro(Guid id);
        public List<Livro> GetTodosLivros();
        public void AlterarLivro(Livro livro);
        public void RemoveLivro(Livro livr);
    }
}
