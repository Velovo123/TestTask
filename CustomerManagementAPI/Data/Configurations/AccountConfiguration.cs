using CustomerManagementAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerManagementAPI.Data.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasOne(a => a.Incident)
                   .WithMany(i => i.Accounts)
                   .HasForeignKey(a => a.IncidentName) 
                   .HasPrincipalKey(i => i.IncidentName) 
                   .OnDelete(DeleteBehavior.Cascade); 

            builder.HasData(
                new Account
                {
                    Id = new Guid("0442326b-5e02-4d78-948f-b30e743a9d0e"),
                    Name = "Account1",
                    IncidentName = "INC001"
                },
                new Account
                {
                    Id = new Guid("675895dc-8d7a-485a-9abd-37125a5fa7d2"),
                    Name = "Account2",
                    IncidentName = "INC002"
                }
            );
        }
    }
}
