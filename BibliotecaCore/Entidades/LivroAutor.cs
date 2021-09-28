using System;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaCore.Entidades
{
    public class LivroAutor
    {
        public Guid LivroId { get; set; }
        public Livro Livro { get; set; }
        public Guid AutorId { get; set; }
        public Autor Autor { get; set; }
    }
}