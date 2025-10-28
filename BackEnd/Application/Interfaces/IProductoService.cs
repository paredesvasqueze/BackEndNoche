using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProductoService
    {
        Task<IEnumerable<Producto>> ObtenerTodosAsync();
        Task<Producto?> ObtenerPorIdAsync(int id);
        Task<int> CrearAsync(Producto dto);
        Task<int> ActualizarAsync(Producto dto);
        Task<int> EliminarAsync(int id);
    }
}
