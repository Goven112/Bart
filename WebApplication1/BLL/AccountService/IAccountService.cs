using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Dto;
using WebApplication1.Model;

namespace WebApplication1.BLL.AccountService
{
    public interface IAccountService
    {
        Task CreateAccountAsync(AccountDto accountDto);
        Task<IEnumerable<Account>> GetAccounts();
    }
}
