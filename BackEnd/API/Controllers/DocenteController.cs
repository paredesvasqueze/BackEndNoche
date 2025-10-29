using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocenteController : ControllerBase
    {
        private readonly IDocenteService _service;
        private readonly ILogger<DocenteController> _logger;

        public DocenteController(IDocenteService service, ILogger<DocenteController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var docentes = await _service.ObtenerTodosAsync();
            return Ok(docentes);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var docente = await _service.ObtenerPorIdAsync(id);
            if (docente == null)
                return NotFound();
            return Ok(docente);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Docente dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newId = await _service.CrearAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = newId }, new { Id = newId });
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Docente dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var rows = await _service.ActualizarAsync(dto);
            if (rows == 0)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var rows = await _service.EliminarAsync(id);
            if (rows == 0)
                return NotFound();

            return NoContent();
        }
    }
}
