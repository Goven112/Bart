using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Model
{
   
    
    public class TaskDbContext : DbContext
    {

        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
        {

        }
        public DbSet<Incident>  Incidents { get; set; }
        public DbSet<Account>  Accounts { get; set; }
        public DbSet<Contact> Contacts   { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Account>()
                .HasIndex(u => u.Name)
                .IsUnique();

            builder.Entity<Contact>()
                .HasIndex(u => u.Email)
                .IsUnique();

            builder.Entity<Incident>()
               .HasIndex(u => u.Name)
               .IsUnique();

            builder.Entity<Incident>()
                .Property(b => b.Name)
                .ValueGeneratedOnAdd();


            builder.Entity<Account>(account =>
            {
                account.HasOne(a => a.Incident)
                    .WithMany(i => i.Accounts)
                    .HasForeignKey(a => a.IncidentId);
            });

            builder.Entity<Contact>(contact =>
            {
                contact.HasOne(c => c.Account)
                    .WithMany(a => a.Contacts)
                    .HasForeignKey(c => c.AccountId);
            });

        }

    }


}
