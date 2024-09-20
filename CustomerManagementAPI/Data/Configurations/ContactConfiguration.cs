using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerManagementAPI.Data.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasData(
               new Contact
               {
                   Id = Guid.NewGuid(),
                   FirstName = "John",
                   LastName = "Doe",
                   Email = "john.doe@example.com",
                   AccountId = new Guid("0442326b-5e02-4d78-948f-b30e743a9d0e") 
               },
               new Contact
               {
                   Id = Guid.NewGuid(),
                   FirstName = "Jane",
                   LastName = "Doe",
                   Email = "jane.doe@example.com",
                   AccountId = new Guid("675895dc-8d7a-485a-9abd-37125a5fa7d2")
               }
           );
        }
    }
}
