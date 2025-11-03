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
    public class GradoRepository : IGradoRepository
    {
        private readonly string _connectionString;

        public GradoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private SqlConnection GetConnection() => new SqlConnection(_connectionString);

        public async Task<IEnumerable<Grado>> ObtenerTodosAsync()
        {
            await using var conn = GetConnection();
            var items = await conn.QueryAsync<Grado>(
                "sp_Grado_GetAll",
                commandType: CommandType.StoredProcedure);
            return items;
        }

        public async Task<Grado?> ObtenerPorIdAsync(int id)
        {
            await using var conn = GetConnection();
            var item = await conn.QueryFirstOrDefaultAsync<Grado>(
                "sp_Grado_GetById",
                new { IdGrado = id },
                commandType: CommandType.StoredProcedure);
            return item;
        }

        public async Task<int> InsertarAsync(Grado Grado)
        {
            await using var conn = GetConnection();
            var newId = await conn.QuerySingleAsync<int>(
                "sp_Grado_Insert",
                new { Grado.IdColegio, Grado.Nivel, Grado.NombreGrado, Grado.Seccion, Grado.Tutor, Grado.Estado },
                commandType: CommandType.StoredProcedure);
            return newId;
        }

        public async Task<int> ActualizarAsync(Grado Grado)
        {
            await using var conn = GetConnection();
            var rows = await conn.QuerySingleAsync<int>(
                "sp_Grado_Update",
                new { Grado.IdGrado, Grado.IdColegio, Grado.Nivel, Grado.NombreGrado, Grado.Seccion, Grado.Tutor, Grado.Estado },
                commandType: CommandType.StoredProcedure);
            return rows;
        }

        public async Task<int> EliminarAsync(int id)
        {
            await using var conn = GetConnection();
            var rows = await conn.QuerySingleAsync<int>(
               "sp_Grado_Delete",
                new { IdGrado = id },
                commandType: CommandType.StoredProcedure);
            return rows;
        }
    }
}

