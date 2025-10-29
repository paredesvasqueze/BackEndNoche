using Dapper;
using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class DocenteRepository : IDocenteRepository
    {
        private readonly string _connectionString;

        public DocenteRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private SqlConnection GetConnection() => new SqlConnection(_connectionString);

        public async Task<IEnumerable<Docente>> ObtenerTodosAsync()
        {
            using var conn = GetConnection();
            return await conn.QueryAsync<Docente>(
                "sp_Docentes_GetAll",
                commandType: CommandType.StoredProcedure);
        }

        public async Task<Docente?> ObtenerPorIdAsync(int id)
        {
            using var conn = GetConnection();
            return await conn.QueryFirstOrDefaultAsync<Docente>(
                "sp_Docentes_GetById",
                new { IdDocente = id },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> InsertarAsync(Docente docente)
        {
            using var conn = GetConnection();
            var newId = await conn.QuerySingleAsync<int>(
                "sp_Docentes_Insert",
                new
                {
                    docente.IdColegio,
                    docente.Nombres,
                    docente.Apellidos,
                    docente.DNI,
                    docente.Email,
                    docente.Telefono,
                    docente.Especialidad,
                    docente.FechaIngreso,
                    docente.Estado
                },
                commandType: CommandType.StoredProcedure);

            return newId;
        }

        public async Task<int> ActualizarAsync(Docente docente)
        {
            using var conn = GetConnection();
            var rows = await conn.ExecuteAsync(
                "sp_Docentes_Update",
                new
                {
                    docente.IdDocente,
                    docente.IdColegio,
                    docente.Nombres,
                    docente.Apellidos,
                    docente.DNI,
                    docente.Email,
                    docente.Telefono,
                    docente.Especialidad,
                    docente.FechaIngreso,
                    docente.Estado
                },
                commandType: CommandType.StoredProcedure);

            return rows;
        }

        public async Task<int> EliminarAsync(int id)
        {
            using var conn = GetConnection();
            var rows = await conn.ExecuteAsync(
                "sp_Docentes_Delete",
                new { IdDocente = id },
                commandType: CommandType.StoredProcedure);

            return rows;
        }
    }
}
