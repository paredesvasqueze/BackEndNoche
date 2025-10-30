using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICursoService
    {
        Task<IEnumerable<Curso>> GetAllAsync();
        Task<Curso> GetByIdAsync(int id);
        Task<int> AddAsync(Curso curso);
        Task<int> UpdateAsync(Curso curso);
        Task<int> DeleteAsync(int id);
    }
}
