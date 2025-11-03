using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {

        private readonly IAlumnoService _service;
        private readonly ILogger<AlumnoController> logger;


        public AlumnoController(IAlumnoService service)
        {
            _service = service;
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var items = await _service.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Add([FromBody] Alumno dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var newId = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = newId }, new { Id = newId });
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Alumno dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            //if (id != dto.Id) return BadRequest("Id No Encontrado");

            var rows = await _service.UpdateAsync(dto);
            if (rows == 0) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var rows = await _service.DeleteAsync(id);
            if (rows == 0) return NotFound();
            return NoContent();
        }
    }
}

