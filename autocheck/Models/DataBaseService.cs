using System;
using System.Collections.Generic;
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

            // Criação das tabelas necessárias
            _db.CreateTableAsync<Carro>().Wait();
            _db.CreateTableAsync<VeiculoSelecionado>().Wait();
            _db.CreateTableAsync<Usuario>().Wait();
        }

        // Salvar veículo selecionado
        public Task<int> SalvarVeiculoSelecionado(VeiculoSelecionado veiculoSelecionado)
        {
            return _db.InsertAsync(veiculoSelecionado);
        }

        // Listar carros
        public Task<List<Carro>> ListarCarros()
        {
            return _db.Table<Carro>().ToListAsync();
        }

        // Salvar usuário
        public Task<int> SalvarUsuario(Usuario usuario)
        {
            return _db.InsertAsync(usuario);
        }

        // Listar clientes
        public Task<List<Usuario>> ListarCliente()
        {
            return _db.Table<Usuario>().ToListAsync();
        }

        // Deletar usuário por ID
        public Task<int> DeletarUsuario(int usuarioId)
        {
            return _db.DeleteAsync<Usuario>(usuarioId);
        }
    }
}