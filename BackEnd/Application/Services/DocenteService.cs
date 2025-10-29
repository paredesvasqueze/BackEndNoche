using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class DocenteService : IDocenteService
    {
        private readonly IDocenteRepository _repo;

        public DocenteService(IDocenteRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Docente>> ObtenerTodosAsync()
        {
            return await _repo.ObtenerTodosAsync();
        }

        public async Task<Docente?> ObtenerPorIdAsync(int id)
        {
            return await _repo.ObtenerPorIdAsync(id);
        }

        public async Task<int> CrearAsync(Docente docente)
        {
            return await _repo.InsertarAsync(docente);
        }

        public async Task<int> ActualizarAsync(Docente docente)
        {
            return await _repo.ActualizarAsync(docente);
        }

        public async Task<int> EliminarAsync(int id)
        {
            return await _repo.EliminarAsync(id);
        }
    }
}
