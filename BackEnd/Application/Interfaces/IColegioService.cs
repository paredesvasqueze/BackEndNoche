using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IColegioService
    {
        Task<IEnumerable<Colegio>> GetAllAsync();
        Task<Colegio?> GetByIdAsync(int id);
        Task<int> AddAsync(Colegio colegio);
        Task<int> UpdateAsync(Colegio colegio);
        Task<int> DeleteAsync(int id);
    }
}
