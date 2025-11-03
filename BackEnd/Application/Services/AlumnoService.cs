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
    public class AlumnoService : IAlumnoService
    {
        private readonly IAlumnoRepository _repo;

        public AlumnoService(IAlumnoRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Alumno>> GetAllAsync()
        {
            var entidades = await _repo.GetAllAsync();
            return entidades;
        }

        public async Task<Alumno?> GetByIdAsync(int id)
        {
            var entidad = await _repo.GetByIdAsync(id);
            if (entidad == null) return null;
            return entidad;
        }

        public async Task<int> AddAsync(Alumno dto)
        {
            return await _repo.AddAsync(dto);
        }

        public async Task<int> UpdateAsync(Alumno dto)
        {
            return await _repo.UpdateAsync(dto);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }
    }
}
