using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class GradoService : IGradoService
    {
        private readonly IGradoRepository _repo;

        public GradoService(IGradoRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Grado>> ObtenerTodosAsync()
        {
            var entidades = await _repo.ObtenerTodosAsync();
            return entidades;
        }

        public async Task<Grado?> ObtenerPorIdAsync(int id)
        {
            var e = await _repo.ObtenerPorIdAsync(id);
            if (e == null) return null;
            return e;
        }

        public async Task<int> CrearAsync(Grado dto)
        {

            return await _repo.InsertarAsync(dto);
        }

        public async Task<int> ActualizarAsync(Grado dto)
        {
            return await _repo.ActualizarAsync(dto);
        }

        public async Task<int> EliminarAsync(int id)
        {
            return await _repo.EliminarAsync(id);
        }
    }
}