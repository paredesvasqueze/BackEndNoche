using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IMatriculasService
    {
        Task<IEnumerable<Matricula>> ObtenerTodosAsync();
        Task<Matricula?> ObtenerPorIdAsync(int id);
        Task<int> InsertarAsync(Matricula matricula);
        Task<int> ActualizarAsync(Matricula matricula);
        Task<int> EliminarAsync(int id);
    }
}