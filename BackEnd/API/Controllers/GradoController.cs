using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GradoController : ControllerBase
    {
        private readonly IGradoService _service;
        private readonly ILogger<GradoController> _logger;

        public GradoController(IGradoService service, ILogger<GradoController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var items = await _service.ObtenerTodosAsync();
            return Ok(items);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _service.ObtenerPorIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Grado dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var newId = await _service.CrearAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = newId }, new { Id = newId });
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Grado dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            //if (id != dto.Id) return BadRequest("Id No Encontrado");

            var rows = await _service.ActualizarAsync(dto);
            if (rows == 0) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var rows = await _service.EliminarAsync(id);
            if (rows == 0) return NotFound();
            return NoContent();
        }
    }
}
