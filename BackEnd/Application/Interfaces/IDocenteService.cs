using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IDocenteService
    {
        Task<IEnumerable<Docente>> ObtenerTodosAsync();
        Task<Docente?> ObtenerPorIdAsync(int id);
        Task<int> CrearAsync(Docente docente);
        Task<int> ActualizarAsync(Docente docente);
        Task<int> EliminarAsync(int id);
    }
}
