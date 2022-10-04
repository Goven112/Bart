using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Interfaces;
using WebApplication1.Model;

namespace WebApplication1.Repositories
{
    public class ContactRepository : IContactRepository
    {

        private readonly TaskDbContext taskDbContext;

        public ContactRepository(TaskDbContext postContext)
        {
            this.taskDbContext = postContext;
        }
        public async Task<int> Add(Contact contact)
        {
            var account = await taskDbContext.Contacts.AddAsync(contact);
            
            return account.Entity.Id;
        }
        public  async Task Update(Contact contact)
        {
            taskDbContext.Contacts.Update(contact);

            await taskDbContext.SaveChangesAsync();
        }

        public async Task<Contact> FindContactByEmail(string contactEmail)
        {
            var contactCheck = await taskDbContext.Contacts.FindAsync(contactEmail);

            if (contactCheck == null)
            {
                return null;
            }

            return contactCheck;

        }
        public async Task<IEnumerable<Contact>> GetContacts()
        {
            return await taskDbContext.Contacts.ToListAsync();
        }
    }
}
