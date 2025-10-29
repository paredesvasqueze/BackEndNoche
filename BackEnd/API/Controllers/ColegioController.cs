using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ColegioController : ControllerBase
    {
        private readonly IColegioService _service;
        private readonly ILogger<ColegioController> _logger;

        public ColegioController(IColegioService service, ILogger<ColegioController> logger)
        {
            _service = service;
            _logger = logger;
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
        public async Task<IActionResult> Create([FromBody] Colegio dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var newId =  await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.IdColegio }, new { Id = dto.IdColegio });
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Colegio dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var existing = await _service.UpdateAsync(dto);
            if (existing == 0) return NotFound();            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _service.DeleteAsync(id);
            if (existing == 0) return NotFound();
            return NoContent();
        }   


    }
}
