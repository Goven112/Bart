using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.BLL.ContactService
{
    public interface IContactService
    {
        Task<int> CreateContactAsync(Contact incidentdto);
        Task<IEnumerable<Contact>> GetContacts();
    }
}
