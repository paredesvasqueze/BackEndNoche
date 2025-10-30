using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;

namespace Application.Services
{
    public class MatriculasService : IMatriculasService
    {
        private readonly IMatriculaRepository _repository;

        public MatriculasService(IMatriculaRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Matricula>> ObtenerTodosAsync()
        {
            return _repository.ObtenerTodosAsync();
        }

        public Task<Matricula?> ObtenerPorIdAsync(int id)
        {
            return _repository.ObtenerPorIdAsync(id);
        }

        public Task<int> InsertarAsync(Matricula matricula)
        {
            return _repository.InsertarAsync(matricula);
        }

        public Task<int> ActualizarAsync(Matricula matricula)
        {
            return _repository.ActualizarAsync(matricula);
        }

        public Task<int> EliminarAsync(int id)
        {
            return _repository.EliminarAsync(id);
        }
    }
}
