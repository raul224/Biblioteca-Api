using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaCore.Entidades;

namespace BibliotecaCore.Requests
{
    public class LivroRequest
    {
        public string Titulo { get; set; }
        public string ISBN { get; set; }
        public DateTime DataPublicacao { get; set; }
        public List<Guid> Autores { get; set; }
    }
}
