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
    public class ColegioService : IColegioService
    {
        private readonly IColegioRepository _colegioRepository;
        public ColegioService(IColegioRepository colegioRepository)
        {
            _colegioRepository = colegioRepository;
        }
        public async Task<IEnumerable<Colegio>> GetAllAsync()
        {
            var entidades = await _colegioRepository.GetAllAsync();
            return entidades;
        }
        public async Task<Colegio?> GetByIdAsync(int id)
        {
            var e = await _colegioRepository.GetByIdAsync(id);
            if (e == null) return null;
            return e;
        }
        public async Task<int> AddAsync(Colegio colegio)
        {
            return await _colegioRepository.AddAsync(colegio);
        }
        public async Task<int> UpdateAsync(Colegio colegio)
        {
            return await _colegioRepository.UpdateAsync(colegio);
        }
        public async Task<int> DeleteAsync(int id)
        {
            return await _colegioRepository.DeleteAsync(id);
        }
    }
}
