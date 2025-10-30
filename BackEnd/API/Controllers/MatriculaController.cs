using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MatriculaController : ControllerBase
    {
        private readonly IMatriculasService _service;

        public MatriculaController(IMatriculasService service)
        {
            _service = service;
        }

        // ✅ GET: api/matricula
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _service.ObtenerTodosAsync();
            return Ok(data);
        }

        // ✅ GET: api/matricula/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var matricula = await _service.ObtenerPorIdAsync(id);
            if (matricula == null)
                return NotFound(new { message = $"No se encontró la matrícula con ID {id}." });

            return Ok(matricula);
        }

        // ✅ POST: api/matricula
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] Matricula matricula)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newId = await _service.InsertarAsync(matricula);

            // Devuelve el nuevo recurso creado y su ubicación
            return CreatedAtAction(nameof(GetById), new { id = newId }, new { id = newId });
        }

        // ✅ PUT: api/matricula/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Matricula matricula)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            matricula.IdMatricula = id;

            var rows = await _service.ActualizarAsync(matricula);

            if (rows == 0)
                return NotFound(new { message = $"No se encontró la matrícula con ID {id} para actualizar." });

            return NoContent(); // 204 = éxito sin cuerpo
        }

        // ✅ DELETE: api/matricula/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var rows = await _service.EliminarAsync(id);

            if (rows == 0)
                return NotFound(new { message = $"No se encontró la matrícula con ID {id} para eliminar." });

            return NoContent();
        }
    }
}
