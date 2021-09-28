using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaCore.Entidades
{
    public class Livro
    {
        [Key]
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string ISBN { get; set; }
        public DateTime DataPublicacao { get; set; }
        public List<LivroAutor> Autores { get; set; } = new List<LivroAutor>();
    }
}
