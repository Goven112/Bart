using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Dto;
using WebApplication1.Interfaces;
using WebApplication1.Model;
using System.Linq;

namespace WebApplication1.Repositories
{
    public class IncidentRepository : IIncidentRepository
    {

        private readonly TaskDbContext taskDbContext;
      
        public IncidentRepository(TaskDbContext postContext)
        {
            this.taskDbContext = postContext;
           
        }
        public async Task<string> Add(Incident incident)
        {
            var newIncident = await taskDbContext.Incidents.AddAsync(incident);
            
            return newIncident.Entity.Name;
        }


        public async Task<ActionResult<IEnumerable<Incident>>> GetIncidentst()
        {
           return await taskDbContext.Incidents.ToListAsync();
        }

        public async Task<Incident> FindAccountByName(string accountName)
        {
            var accountCheck = await taskDbContext.Incidents.FindAsync(accountName);

            if (accountCheck == null)
            {
                return null;
            }

            return accountCheck;

        }

        public async Task<bool> CreateIncidentAsync(IncidentDto incidentdto, Incident incident)
        {
            var account = taskDbContext.Set<Account>().FirstOrDefault(p=>p.Name == incidentdto.AccontName);

            var contact = taskDbContext.Set<Contact>().FirstOrDefault(p => p.Email == incidentdto.Email);

            if (account == null)
            {
                return false;
            }

            if (contact != null)
            {
                contact.First_Name = incidentdto.FirstNameContact;

                contact.Last_Name = incidentdto.LastNameContact;

                if (contact.AccountId == 0)
                {
                    contact.AccountId = account.Id;
                }

                taskDbContext.Contacts.Update(contact);

                await taskDbContext.SaveChangesAsync();
            }
            else
            {
                var newContact = new Contact() { First_Name = incidentdto.FirstNameContact, Last_Name = incidentdto.LastNameContact, Email = incidentdto.Email, AccountId = account.Id };

                await taskDbContext.Contacts.AddAsync(newContact);

                var nameIncident = await Add(incident);

                account.IncidentId = nameIncident;
            }

            await taskDbContext.SaveChangesAsync();

            return true;

        }
        public async Task<bool> DeleteById(string id)
        {
            var incident = await taskDbContext.Incidents.FindAsync(id);
            
            var incidentTrack = taskDbContext.Incidents.Remove(incident);

            if (incidentTrack == null)
            {
                return false;
            }
            await taskDbContext.SaveChangesAsync();
            
            return true;
        }
        public bool IncidentExists(string id)
        {
            return taskDbContext.Incidents.Any(e => e.Name == id);
        }
    }
}
