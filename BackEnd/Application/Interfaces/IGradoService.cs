using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IGradoService
    {
        Task<IEnumerable<Grado>> ObtenerTodosAsync();
        Task<Grado?> ObtenerPorIdAsync(int id);
        Task<int> CrearAsync(Grado dto);
        Task<int> ActualizarAsync(Grado dto);
        Task<int> EliminarAsync(int id);
    }
}