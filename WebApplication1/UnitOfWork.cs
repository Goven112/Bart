using System.Threading.Tasks;
using WebApplication1.Interfaces;
using WebApplication1.Model;
using WebApplication1.Repositories;

namespace WebApplication1
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TaskDbContext dc;

        public UnitOfWork(TaskDbContext dc)
        {
            this.dc = dc;
        }

        public IAccountRepository accountRepository => new AccountRepository(dc);

        public IIncidentRepository incidentRepository => new IncidentRepository(dc);

        public IContactRepository contactRepository => new ContactRepository(dc);

        public async Task<bool> SavaAsync()
        {
            return await dc.SaveChangesAsync() > 0;
        }

    }
}
