using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Dto;
using WebApplication1.Model;

namespace WebApplication1.Interfaces
{
    public interface IIncidentRepository
    {

        Task<string> Add(Incident task);
        Task<ActionResult<IEnumerable<Incident>>> GetIncidentst();
        Task<bool> CreateIncidentAsync(IncidentDto incidentdto, Incident incident);
        Task<Incident> FindAccountByName(string accountName);
        Task<bool> DeleteById(string id);
    }
}
