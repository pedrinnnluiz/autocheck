using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace autocheck.Models
{
    public class DataBaseService
    {
        private readonly SQLiteAsyncConnection _db;

        public DataBaseService(string dbPath)
        {
            _db = new SQLiteAsyncConnection(dbPath);

            _db.CreateTableAsync<Carro>().Wait();
            _db.CreateTableAsync<VeiculoSelecionado>().Wait();
            _db.CreateTableAsync<Usuario>().Wait();
        }

        public Task<int> SalvarUsuario(Usuario usuario)
        {
            usuario.Email = usuario.Email.Trim().ToLower();
            return _db.InsertAsync(usuario);
        }

        public Task<List<Usuario>> ListarUsuario()
        {
            return _db.Table<Usuario>().ToListAsync();
        }

        public Task<int> DeletarUsuario(int usuarioId)
        {
            return _db.DeleteAsync<Usuario>(usuarioId);
        }

        public Task<Usuario> GetUsuario(int id)
        {
            return _db.Table<Usuario>()
                      .Where(u => u.Id == id)
                      .FirstOrDefaultAsync();
        }

        public Task<Usuario> LoginAsync(string email, string senha)
        {
            email = email.Trim().ToLower();

            return _db.Table<Usuario>()
                      .Where(u => u.Email == email && u.Senha == senha)
                      .FirstOrDefaultAsync();
        }


        public Task<List<Carro>> ListarCarros()
        {
            return _db.Table<Carro>().ToListAsync();
        }

        

        public Task<int> SalvarVeiculoSelecionado(VeiculoSelecionado veiculo)
        {
            return _db.InsertAsync(veiculo);
        }

        public Task<List<VeiculoSelecionado>> GetLocacoesByUsuario(int usuarioId)
        {
            return _db.Table<VeiculoSelecionado>()
                      .Where(v => v.UsuarioId == usuarioId)
                      .ToListAsync();
        }
    }
}