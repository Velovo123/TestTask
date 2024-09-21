using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CustomerManagementAPI.Models;

[Index(nameof(Name), IsUnique = true)]
public class Account : BaseEntity
{
    [Required]
    [StringLength(100, ErrorMessage = "Name can't be longer than 100 characters.")]
    public string Name { get; set; } = null!;
    public Incident? Incident { get; set; }

    [StringLength(50, ErrorMessage = "Incident name can't be longer than 50 characters.")]
    public string? IncidentName { get; set; }

    [Required(ErrorMessage = "At least one contact is required.")]
    public ICollection<Contact> Contacts { get; set; } = null!;

}
