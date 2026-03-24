using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;


namespace autocheck.Models
{
    public class DataBaseService
    {
        readonly SQLiteAsyncConnection _db;



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
}
