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
    public class ColegioRepository : IColegioRepository
    {
        private readonly string _connectionString;

        public ColegioRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private SqlConnection GetConnection() => new SqlConnection(_connectionString);

        public async Task<IEnumerable<Colegio>> GetAllAsync()
        {
            await using var conn = GetConnection();
            var items = await conn.QueryAsync<Colegio>(
                "sp_Colegio_GetAll",
                commandType: CommandType.StoredProcedure);
            return items;
        }

        public async Task<Colegio?> GetByIdAsync(int id)
        {
            await using var conn = GetConnection();
            var item = await conn.QueryFirstOrDefaultAsync<Colegio>(
                "sp_Colegio_GetById",
                new { IdColegio = id },
                commandType: CommandType.StoredProcedure);
            return item;
        }

        public async Task<int> AddAsync(Colegio colegio)
        {
            await using var conn = GetConnection();
            var newId = await conn.QuerySingleAsync<int>(
                "sp_Colegio_Insert",
                new
                {
                    colegio.Nombre,
                    colegio.RUC,
                    colegio.Direccion,
                    colegio.Telefono,
                    colegio.Email,
                    colegio.Director,
                    colegio.Estado
                },
                commandType: CommandType.StoredProcedure);
            return newId;
        }

        public async Task<int> UpdateAsync(Colegio colegio)
        {
            await using var conn = GetConnection();
            var rows = await conn.QuerySingleAsync<int>(
                "sp_Colegio_Update",
                new
                {
                    colegio.IdColegio,
                    colegio.Nombre,
                    colegio.RUC,
                    colegio.Direccion,
                    colegio.Telefono,
                    colegio.Email,
                    colegio.Director,
                    colegio.Estado
                },
                commandType: CommandType.StoredProcedure);
            return rows;
        }

        public async Task<int> DeleteAsync(int id)
        {
            await using var conn = GetConnection();
            var rows = await conn.QuerySingleAsync<int>(
                "sp_Colegio_Delete",
                new { IdColegio = id },
                commandType: CommandType.StoredProcedure);
            return rows;
        }
    }
}
