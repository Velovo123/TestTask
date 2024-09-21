using System.ComponentModel.DataAnnotations;

namespace CustomerManagementAPI.Models;

public class Contact : BaseEntity
{
    [Required]
    public string FirstName { get; set; } = null!;

    [Required]
    public string LastName { get; set; } = null!;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;

    public Account Account { get; set; } = null!;
    public Guid? AccountId { get; set; }

}
