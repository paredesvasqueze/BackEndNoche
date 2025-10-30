using Domain.Entities;

namespace Infrastructure.Interfaces
{
    public interface IMatriculaRepository
    {
        Task<IEnumerable<Matricula>> ObtenerTodosAsync();
        Task<Matricula?> ObtenerPorIdAsync(int id);
        Task<int> InsertarAsync(Matricula matricula);
        Task<int> ActualizarAsync(Matricula matricula);
        Task<int> EliminarAsync(int id);
    }
}
