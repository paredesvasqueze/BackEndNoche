using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // 🔹 Recomendado: todas las APIs comienzan con /api
    public class CursoController : ControllerBase
    {
        private readonly ICursoService _service;
        private readonly ILogger<CursoController> _logger;

        public CursoController(ICursoService service, ILogger<CursoController> logger)
        {
            _service = service;
            _logger = logger;
        }

        // ✅ GET api/curso
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _service.GetAllAsync();
            return Ok(items);
        }

        // ✅ GET api/curso/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null)
            {
                _logger.LogWarning("Curso con ID {Id} no encontrado", id);
                return NotFound(new { message = $"No se encontró el curso con ID {id}" });
            }

            return Ok(item);
        }

        // ✅ POST api/curso
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Curso dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newId = await _service.AddAsync(dto);
            _logger.LogInformation("Curso creado con ID {Id}", newId);

            return CreatedAtAction(nameof(GetById), new { id = newId }, new { Id = newId });
        }

        // ✅ PUT api/curso/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Curso dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            dto.IdCurso = id; // 🔹 Aseguramos que el ID del cuerpo coincida con el de la URL

            var rows = await _service.UpdateAsync(dto);

            if (rows == 0)
            {
                _logger.LogWarning("Intento de actualizar curso inexistente con ID {Id}", id);
                return NotFound(new { message = $"No se encontró el curso con ID {id} para actualizar" });
            }

            return Ok(new { message = "Curso actualizado correctamente" });
        }

        // ✅ DELETE api/curso/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var rows = await _service.DeleteAsync(id);

            if (rows == 0)
            {
                _logger.LogWarning("Intento de eliminar curso inexistente con ID {Id}", id);
                return NotFound(new { message = $"No se encontró el curso con ID {id} para eliminar" });
            }

            _logger.LogInformation("Curso eliminado con ID {Id}", id);
            return Ok(new { message = "Curso eliminado correctamente" });
        }
    }
}
