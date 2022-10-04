using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Dto;
using WebApplication1.Model;

namespace WebApplication1.BLL
{
    public interface IIncidentService
    {
        Task<bool> CreateIncidentAsync(IncidentDto incidentdto);
        Task<bool> DeleteById(string id);
        Task<ActionResult<IEnumerable<Incident>>> GetIncidentst();
        Task<ActionResult<Incident>> FindAccountByName(string accountName);
    }
}
