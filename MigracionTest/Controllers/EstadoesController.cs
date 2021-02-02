using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DomainCore.Data.Entities;
using DomainCore.Core.Interfaces;

namespace MigracionTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoesController : ControllerBase
    {
        private readonly IEstadosRep _estadosRep;

        public EstadoesController(IEstadosRep estadosRep)
        {
            _estadosRep = estadosRep;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estado>>> GetEstado()
        {
            return await _estadosRep.GetAll();
        }

        
        [HttpGet("{name}")]
        public async Task<ActionResult<Estado>> GetEstado(string name)
        {
            var estado = await _estadosRep.GetByName(name);

            return estado;
        }

        [HttpPost]
        public async Task<ActionResult<Estado>> PostEstado(Estado estado)
        {
            var created = await _estadosRep.Create(estado);
            if (!created) return BadRequest();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstado(int id, Estado estado)
        {
            if (id != estado.Id)
                return BadRequest();

            var updated = await _estadosRep.Update(id, estado);
            if (!updated) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Estado>> DeleteEstado(int id)
        {
            var deleted = await _estadosRep.Delete(id);
            if (!deleted) return BadRequest();

            return Ok();
        }

    }
}
