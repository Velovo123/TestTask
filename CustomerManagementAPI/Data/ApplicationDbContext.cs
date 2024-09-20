using Microsoft.EntityFrameworkCore;

namespace CustomerManagementAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<Incident>())
            {
                if (entry.State == EntityState.Added && string.IsNullOrEmpty(entry.Entity.IncidentName))
                {
                    entry.Entity.IncidentName = $"INC-{DateTime.UtcNow:MM/dd/yyyyHH:mm:ss}";  
                }
            }
            return base.SaveChanges();
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Incident> Incidents { get; set; }
    }
}
