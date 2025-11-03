using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class AlumnoRepository : IAlumnoRepository
    {
        private readonly string _connectionString;

        public AlumnoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private SqlConnection GetConnection() => new SqlConnection(_connectionString);

        public async Task<IEnumerable<Alumno>> GetAllAsync()
        {
            await using var conn = GetConnection();
            var items = await conn.QueryAsync<Alumno>(
                "sp_Alumno_GetAll",
                commandType: CommandType.StoredProcedure);
            return items;
        }

        public async Task<Alumno?> GetByIdAsync(int id)
        {
            await using var conn = GetConnection();
            var item = await conn.QueryFirstOrDefaultAsync<Alumno>(
                "sp_Alumno_GetById",
                new { IdAlumno = id },
                commandType: CommandType.StoredProcedure);
            return item;
        }

        public async Task<int> AddAsync(Alumno alumno)
        {
            await using var conn = GetConnection();
            var newId = await conn.QuerySingleAsync<int>(
                "sp_Alumno_Insert",
                new
                {
                    alumno.IdColegio, alumno.Nombres, alumno.Apellidos, alumno.DNI, alumno.FechaNacimiento, alumno.Genero, alumno.Direccion, alumno.Telefono, alumno.Email, alumno.Estado
                },
                commandType: CommandType.StoredProcedure);
            return newId;
        }

        public async Task<int> UpdateAsync(Alumno alumno)
        {
            await using var conn = GetConnection();
            var rows = await conn.QuerySingleAsync<int>(
                "sp_Alumno_Update",
                new
                {
                    alumno.IdAlumno, alumno.IdColegio, alumno.Nombres, alumno.Apellidos, alumno.DNI, alumno.FechaNacimiento, alumno.Genero, alumno.Direccion, alumno.Telefono, alumno.Email, alumno.Estado
                },
                commandType: CommandType.StoredProcedure);
            return rows;
        }

        public async Task<int> DeleteAsync(int id)
        {
            await using var conn = GetConnection();
            var rows = await conn.QuerySingleAsync<int>(
                "sp_Alumno_Delete",
                new { IdAlumno = id },
                commandType: CommandType.StoredProcedure);
            return rows;
        }
    }
}
