using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly string _connectionString;

        public ProductoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private SqlConnection GetConnection() => new SqlConnection(_connectionString);

        public async Task<IEnumerable<Producto>> ObtenerTodosAsync()
        {
            await using var conn = GetConnection();
            var items = await conn.QueryAsync<Producto>(
                "sp_Producto_GetAll",
                commandType: CommandType.StoredProcedure);
            return items;
        }

        public async Task<Producto?> ObtenerPorIdAsync(int id)
        {
            await using var conn = GetConnection();
            var item = await conn.QueryFirstOrDefaultAsync<Producto>(
                "sp_Producto_GetById",
                new { Id = id },
                commandType: CommandType.StoredProcedure);
            return item;
        }

        public async Task<int> InsertarAsync(Producto producto)
        {
            await using var conn = GetConnection();
            var newId = await conn.QuerySingleAsync<int>(
                "sp_Producto_Insert",
                new { producto.Nombre, producto.Descripcion, producto.Precio, producto.Stock, producto.CategoriaId },
                commandType: CommandType.StoredProcedure);
            return newId;
        }

        public async Task<int> ActualizarAsync(Producto producto)
        {
            await using var conn = GetConnection();
            var rows = await conn.QuerySingleAsync<int>(
                "sp_Producto_Update",
                new { producto.Id, producto.Nombre, producto.Descripcion, producto.Precio, producto.Stock , producto.CategoriaId  },
                commandType: CommandType.StoredProcedure);
            return rows;
        }

        public async Task<int> EliminarAsync(int id)
        {
            await using var conn = GetConnection();
            var rows = await conn.QuerySingleAsync<int>(
               "sp_Producto_Delete",
                new { Id = id },
                commandType: CommandType.StoredProcedure);
            return rows;
        }
    }
}
