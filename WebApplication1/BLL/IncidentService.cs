using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Dto;
using WebApplication1.Interfaces;
using WebApplication1.Model;

namespace WebApplication1.BLL
{
    public class IncidentService : IIncidentService
    {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public IncidentService(IUnitOfWork unitofWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitofWork;
            
        }

        public async Task<bool> CreateIncidentAsync(IncidentDto incidentdto)
        {
            var incident = _mapper.Map<Incident>(incidentdto);
            return await _unitOfWork.incidentRepository.CreateIncidentAsync(incidentdto, incident);

        }
        public async Task<bool> DeleteById(string id)
        {
           return await _unitOfWork.incidentRepository.DeleteById(id);
        }

        public async Task<ActionResult<IEnumerable<Incident>>> GetIncidentst()
        {
            return await _unitOfWork.incidentRepository.GetIncidentst();
        }

        public async Task<ActionResult<Incident>> FindAccountByName(string accountName)
        {
          return  await _unitOfWork.incidentRepository.FindAccountByName(accountName);
        }

    }
}
