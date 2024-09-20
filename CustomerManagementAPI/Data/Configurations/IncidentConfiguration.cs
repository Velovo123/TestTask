using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerManagementAPI.Data.Configurations
{
    public class IncidentConfiguration : IEntityTypeConfiguration<Incident>
    {
        public void Configure(EntityTypeBuilder<Incident> builder)
        {
            builder.HasData(
                new Incident
                {
                    IncidentName = "INC001",
                    Description = "Initial Incident 1"
                },
                new Incident
                {
                    IncidentName = "INC002",
                    Description = "Initial Incident 2"
                }
            );
           
        }
    }
}
