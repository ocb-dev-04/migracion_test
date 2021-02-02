using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DomainCore.Data.Entities;
using DomainCore.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace MigracionTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly IPersonasRep _personasRep;

        public PersonasController(IPersonasRep personasRep)
        {
            _personasRep = personasRep;
        }
        
        [HttpGet]
        public async Task<IEnumerable<Personas>> GetPersonas()
        {
            return await _personasRep.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Personas>> GetPersonas(int id)
        {
            var personas = await _personasRep.GetById(id);

            if (personas == null)
            {
                return NotFound();
            }

            return personas;
        }
        [HttpPost]
        public async Task<ActionResult<Personas>> PostPersonas(Personas personas)
        {
            var added = await _personasRep.Create(personas);
            if (!added) return NotFound();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonas(int id, Personas personas)
        {
            if (id != personas.Id)
                return BadRequest();

            var update = await _personasRep.Update(id, personas);
            if (!update) return NotFound();

            return NoContent();
        }

        

         [HttpDelete("{id}")]
        public async Task<ActionResult<Personas>> DeletePersonas(int id)
        {
            var deleted = await _personasRep.Delete(id);
            if (!deleted) return NotFound();

            return Ok();
        }

    }
}
