using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DomainCore.Data.Entities;
using DomainCore.Core.Interfaces;

namespace MigracionTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudsController : ControllerBase
    {
        private readonly ISolicitudesRep _solicitudesRep;

        public SolicitudsController(ISolicitudesRep solicitudesRep)
        {
            _solicitudesRep = solicitudesRep;
        }

        [HttpGet]
        public async Task<IEnumerable<Solicitud>> GetSolicitud()
        {
            return await _solicitudesRep.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Solicitud>> GetSolicitud(int id)
        {
            var solicitud = await _solicitudesRep.GetById(id);

            if (solicitud == null)
                return NotFound();

            return solicitud;
        }

        [HttpPost]
        public async Task<ActionResult<Solicitud>> PostSolicitud(Solicitud solicitud)
        {
            var created = await _solicitudesRep.Create(solicitud);
            if (!created) return NotFound();

            return Ok();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutSolicitud(int id, Solicitud solicitud)
        {
            if (id != solicitud.Id)
                return BadRequest();

            var updated = await _solicitudesRep.Update(id, solicitud);
            if (!updated) return NotFound();

            return NoContent();
        }

        

        [HttpDelete("{id}")]
        public async Task<ActionResult<Solicitud>> DeleteSolicitud(int id)
        {
            var deleted = await _solicitudesRep.Delete(id);
            if (!deleted) return NotFound();

            return Ok();
        }

    }
}
