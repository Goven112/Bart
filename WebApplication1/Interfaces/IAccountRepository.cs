using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.Interfaces
{
    public interface IAccountRepository
    {
        Task<int> Add(Account task);

        Task<IEnumerable<Account>> GetAccounts();
        Task Update(Account account);

        Task<Account> FindAccountByName(string accountName);
    }
}
