using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Interfaces;
using WebApplication1.Model;

namespace WebApplication1.Repositories
{
    public class AccountRepository : IAccountRepository
    {

        private readonly TaskDbContext taskDbContext;

        public AccountRepository(TaskDbContext postContext)
        {
            this.taskDbContext = postContext;
        }

        public async Task<IEnumerable<Account>> GetAccounts()
        {
            return await taskDbContext.Accounts.ToListAsync();
        }
        public async Task<int> Add(Account  account)
        {
            var accountCheck = await taskDbContext.Accounts.AddAsync(account);
           
            await taskDbContext.SaveChangesAsync(); 
            
            return accountCheck.Entity.Id ;
        }

        public async Task<Account> FindAccountByName(string accountName)
        {
            var accountCheck =  await taskDbContext.Accounts.FindAsync(accountName);

            if (accountCheck == null)
            {
                return null;
            }

            return accountCheck;

        }
        public async Task Update(Account account)
        {
            taskDbContext.Accounts.Update(account);

            await taskDbContext.SaveChangesAsync();

        }

       



    }
}
