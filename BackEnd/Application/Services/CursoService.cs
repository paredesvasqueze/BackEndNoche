using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CursoService : ICursoService
    {
        private readonly ICursoRepository _repository;

        public CursoService(ICursoRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Curso>> GetAllAsync() => _repository.GetAllAsync();

        public Task<Curso> GetByIdAsync(int id) => _repository.GetByIdAsync(id);

        public Task<int> AddAsync(Curso curso) => _repository.AddAsync(curso);

        public Task<int> UpdateAsync(Curso curso) => _repository.UpdateAsync(curso);

        public Task<int> DeleteAsync(int id) => _repository.DeleteAsync(id);
    }
}
