using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaCore.Entidades;

namespace BibliotecaCore.Requests
{
    public class AutorRequest
    {
        public string nome { get; set; }
        public string sobreNome { get; set; }
        public string email { get; set; }
        public DateTime dataNascimento { get; set; }
    }
}
