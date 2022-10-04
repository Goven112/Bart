using System;
using System.Collections.Generic;
using AutoMapper;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Dto;
using WebApplication1.Interfaces;
using WebApplication1.Model;
using WebApplication1.BLL;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentsController : ControllerBase
    {
        private readonly TaskDbContext _context;

        private readonly IIncidentService _incedentService;
       
        public IncidentsController(TaskDbContext context, IIncidentService incedentService,IUnitOfWork unitOfWork)
        {
            _context = context;
            _incedentService = incedentService;   
        }

        // GET: api/Incidents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Incident>>> GetIncidents()
        {
            return await _incedentService.GetIncidentst();
            
        }

        // GET: api/Incidents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Incident>> GetIncident(string id)
        {
            var incident = await _incedentService.FindAccountByName(id);

            if (incident == null)
            {
                return NotFound();
            }

            return incident;
        }

        // PUT: api/Incidents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIncident(string id, Incident incident)
        {
            if (id != incident.Name)
            {
                return BadRequest();
            }

            _context.Entry(incident).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IncidentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Incidents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostIncident(IncidentDto incidentdto)
        {
            
            if(await _incedentService.CreateIncidentAsync(incidentdto) == false)
            {
                return NotFound();
            }

            return Ok();
        }

        // DELETE: api/Incidents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIncident(string id)
        {
            await _incedentService.DeleteById(id);


            
          

            return NoContent();
        }

        private bool IncidentExists(string id)
        {
            return _context.Incidents.Any(e => e.Name == id);
        }
    }
}
