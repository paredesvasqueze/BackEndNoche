using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IDocenteRepository
    {
        Task<IEnumerable<Docente>> ObtenerTodosAsync();
        Task<Docente?> ObtenerPorIdAsync(int id);
        Task<int> InsertarAsync(Docente docente);
        Task<int> ActualizarAsync(Docente docente);
        Task<int> EliminarAsync(int id);
    }
}
