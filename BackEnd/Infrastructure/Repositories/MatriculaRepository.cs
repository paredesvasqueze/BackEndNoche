using Dapper;
using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class MatriculaRepository : IMatriculaRepository
    {
        private readonly string _connectionString;

        public MatriculaRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private SqlConnection GetConnection() => new SqlConnection(_connectionString);

        public async Task<IEnumerable<Matricula>> ObtenerTodosAsync()
        {
            await using var conn = GetConnection();
            var items = await conn.QueryAsync<Matricula>(
                "sp_Matricula_GetAll",
                commandType: CommandType.StoredProcedure);
            return items;
        }

        public async Task<Matricula?> ObtenerPorIdAsync(int id)
        {
            await using var conn = GetConnection();
            var item = await conn.QueryFirstOrDefaultAsync<Matricula>(
                "sp_Matricula_GetById",
                new { IdMatricula = id },
                commandType: CommandType.StoredProcedure);
            return item;
        }

        public async Task<int> InsertarAsync(Matricula matricula)
        {
            await using var conn = GetConnection();
            var newId = await conn.QuerySingleAsync<int>(
                "sp_Matricula_Insert",
                new
                {
                    matricula.IdAlumno,
                    matricula.IdGrado,
                    matricula.FechaMatricula,
                    matricula.AñoLectivo,
                    matricula.Estado
                },
                commandType: CommandType.StoredProcedure);
            return newId;
        }

        public async Task<int> ActualizarAsync(Matricula matricula)
        {
            await using var conn = GetConnection();
            var rows = await conn.ExecuteAsync(
                "sp_Matricula_Update",
                new
                {
                    matricula.IdMatricula,
                    matricula.IdAlumno,
                    matricula.IdGrado,
                    matricula.FechaMatricula,
                    matricula.AñoLectivo,
                    matricula.Estado
                },
                commandType: CommandType.StoredProcedure);
            return rows;
        }

        public async Task<int> EliminarAsync(int id)
        {
            await using var conn = GetConnection();
            var rows = await conn.ExecuteAsync(
                "sp_Matricula_Delete",
                new { IdMatricula = id },
                commandType: CommandType.StoredProcedure);
            return rows;
        }
    }
}