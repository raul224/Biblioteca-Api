using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaCore.Entidades;

namespace BibliotecaCore.IRepositorios
{
    public interface IRepositorioAutor
    {
        public void Salvar(Autor autor);
        public Autor GetAutor(Guid id);
        public List<Autor> GetTodosAutores();
        public void AlterarAutor(Autor autor);
        public void RemoveAutor(Autor autor);
    }
}
