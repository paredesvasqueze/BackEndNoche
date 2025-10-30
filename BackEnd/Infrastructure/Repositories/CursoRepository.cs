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
    public class CursoRepository : ICursoRepository
    {
        private readonly string _connectionString;

        public CursoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Curso>> GetAllAsync()
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();

            return await conn.QueryAsync<Curso>(
                "sp_Curso_GetAll",
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<Curso> GetByIdAsync(int idCurso)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();

            var curso = await conn.QueryFirstOrDefaultAsync<Curso>(
                "sp_Curso_GetById",
                new { IdCurso = idCurso },
                commandType: CommandType.StoredProcedure
            );

            if (curso == null)
                throw new KeyNotFoundException($"No se encontró el curso con ID {idCurso}");

            return curso;
        }


        // ✅ INSERT devuelve el nuevo ID (SCOPE_IDENTITY)
        public async Task<int> AddAsync(Curso curso)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();

            return await conn.ExecuteScalarAsync<int>(
                "sp_Curso_Insert",
                new
                {
                    curso.IdGrado,
                    curso.NombreCurso,
                    curso.HorasSemanales,
                    curso.DocenteEncargado,
                    curso.Estado
                },
                commandType: CommandType.StoredProcedure
            );
        }

        // ✅ UPDATE devuelve cantidad de filas afectadas (@@ROWCOUNT)
        public async Task<int> UpdateAsync(Curso curso)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();

            return await conn.ExecuteScalarAsync<int>(
                "sp_Curso_Update",
                new
                {
                    curso.IdCurso,
                    curso.IdGrado,
                    curso.NombreCurso,
                    curso.HorasSemanales,
                    curso.DocenteEncargado,
                    curso.Estado
                },
                commandType: CommandType.StoredProcedure
            );
        }

        // ✅ DELETE devuelve cantidad de filas eliminadas (@@ROWCOUNT)
        public async Task<int> DeleteAsync(int idCurso)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();

            return await conn.ExecuteScalarAsync<int>(
                "sp_Curso_Delete",
                new { IdCurso = idCurso },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
