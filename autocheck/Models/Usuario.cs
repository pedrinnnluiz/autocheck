using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace autocheck.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public int Cpf { get; set;  }
        public double Dias { get; set; }
        public double Total { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public double Cep { get; set; }

        public string Nome { get; set; }
        public string Telefone { get; set; }

    }
}
