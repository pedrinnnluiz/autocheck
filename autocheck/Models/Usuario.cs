using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
<<<<<<< HEAD
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

=======

namespace autocheck.Models
{
   public class Usuario
    {
        public int UsuarioId { get; set; }

        public string Nome { get; set; }

        public string Cpf {  get; set; }

        public string Email { get; set; }
        public string Telefone { get; set; } 

        public string Senha { get; set; }

>>>>>>> 62b0968a3129d734e18eb1169337ef7a1f3c434f
    }
}
