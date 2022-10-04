using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Interfaces;
using WebApplication1.Model;

namespace WebApplication1.BLL.ContactService
{
    public class ContactService : IContactService
    {

  
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ContactService(IUnitOfWork unitofWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitofWork;
           
        }


        public async Task<int> CreateContactAsync(Contact incidentdto)
        {
          return  await _unitOfWork.contactRepository.Add(incidentdto);

        }
        public async Task<IEnumerable<Contact>> GetContacts()
        {
            return await _unitOfWork.contactRepository.GetContacts();
        }
    }
}
