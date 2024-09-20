using System.ComponentModel.DataAnnotations;

namespace CustomerManagementAPI.Data;

public class Contact : BaseEntity
{
    [Required]
    public string FirstName { get; set; } = null!;

    [Required]
    public string LastName { get; set; } = null!;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;

    public Account? Account { get; set; }
    public Guid AccountId { get; set; }

}
