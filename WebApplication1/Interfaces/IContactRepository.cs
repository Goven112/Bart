using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.Interfaces
{
    public interface IContactRepository
    {
        Task<int> Add(Contact task);
        Task<IEnumerable<Contact>> GetContacts();
        Task Update(Contact contact);
        Task<Contact> FindContactByEmail(string contactEmail);

    }
}
