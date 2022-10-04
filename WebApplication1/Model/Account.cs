using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Model
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IncidentId { get; set;}
        public Incident Incident { get; set;}

        public ICollection<Contact> Contacts { get; set; }
    }
}
