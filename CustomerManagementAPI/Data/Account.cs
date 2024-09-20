using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CustomerManagementAPI.Data;

[Index(nameof(Account.Name),IsUnique = true)]
public class Account : BaseEntity
{
    [Required]
    public string Name { get; set; } = null!;

    public Incident? Incident { get; set; }
    public string? IncidentName { get; set; }

    public ICollection<Contact> Contacts { get; set; } = null!;

}
