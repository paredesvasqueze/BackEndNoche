using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IAlumnoRepository
    {
        Task<IEnumerable<Alumno>> GetAllAsync();
        Task<Alumno?> GetByIdAsync(int id);
        Task<int> AddAsync(Alumno alumno);
        Task<int> UpdateAsync(Alumno alumno);
        Task<int> DeleteAsync(int id);
    }
}
