using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface ICursoRepository
    {
        Task<IEnumerable<Curso>> GetAllAsync();
        Task<Curso> GetByIdAsync(int idCurso);
        Task<int> AddAsync(Curso curso);
        Task<int> UpdateAsync(Curso curso);
        Task<int> DeleteAsync(int idCurso);
    }
}
