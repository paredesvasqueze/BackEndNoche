using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IGradoRepository
    {
        Task<IEnumerable<Grado>> ObtenerTodosAsync();
        Task<Grado?> ObtenerPorIdAsync(int id);
        Task<int> InsertarAsync(Grado Grado);
        Task<int> ActualizarAsync(Grado Grado);
        Task<int> EliminarAsync(int id);
    }
}
