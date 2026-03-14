using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using autocheck.Models;

namespace autocheck.Models
{
    public class DataBaseService
    {
        readonly SQLiteAsyncConnection _db;

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
}
