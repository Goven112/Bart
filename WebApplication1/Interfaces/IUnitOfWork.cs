using System.Threading.Tasks;

namespace WebApplication1.Interfaces
{
    public interface IUnitOfWork
    {

        IAccountRepository accountRepository { get; }

        IIncidentRepository incidentRepository { get; }

        IContactRepository  contactRepository { get; }

        Task<bool> SavaAsync();

    }
}
