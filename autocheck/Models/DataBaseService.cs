using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
<<<<<<< HEAD

=======
using autocheck.Models;
>>>>>>> 62b0968a3129d734e18eb1169337ef7a1f3c434f

namespace autocheck.Models
{
    public class DataBaseService
    {
        readonly SQLiteAsyncConnection _db;

<<<<<<< HEAD


        public DataBaseService(string dbPath)
        {
            _db = new SQLiteAsyncConnection(dbPath);
            _db.CreateTableAsync<Carro>().Wait();
            _db.CreateTableAsync<VeiculoSelecionado>().Wait();
            _db.CreateTableAsync<Usuario>().Wait();
        }
        public Task<int> SalvarVeiculoSelecionado(VeiculoSelecionado veiculoSelecionado)
        {
            return _db.InsertAsync(veiculoSelecionado);
        }

        public Task <List<Carro>> ListarCarros()
        {
            return _db.Table<Carro>().ToListAsync();
        }

        public Task <int> SalvarUsuario(Usuario usuario)
        {
            return _db.InsertAsync(usuario);
        }

        public Task <List<Usuario>> ListarCliente()
        {
            return _db.Table<Usuario>().ToListAsync();
        }
    }
=======
       public DataBaseService (string dbPath)

        {
            _db = new SQLiteAsyncConnection(dbPath);
            _db.CreateTableAsync<Usuario>().Wait();
            _db.CreateTableAsync<VeiculoSelecionado>().Wait();
        }

        public Task<int> SalvarUsuario(Usuario usuario)
        {
            return _db.InsertAsync(usuario);
        }
        public Task<int> DeletarUsuario (int Usuarioid)
        {
            return _db.DeleteAsync<Usuario>(Usuarioid);
        }
    } 
>>>>>>> 62b0968a3129d734e18eb1169337ef7a1f3c434f
}
