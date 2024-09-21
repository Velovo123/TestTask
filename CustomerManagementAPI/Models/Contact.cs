using System.ComponentModel.DataAnnotations;

namespace CustomerManagementAPI.Models;

public class Contact : BaseEntity
{
    [Required(ErrorMessage = "First name is required.")]
    [StringLength(50, ErrorMessage = "First name can't be longer than 50 characters.")]
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = "Last name is required.")]
    [StringLength(50, ErrorMessage = "Last name can't be longer than 50 characters.")]
    public string LastName { get; set; } = null!;

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    [StringLength(100, ErrorMessage = "Email can't be longer than 100 characters.")]
    public string Email { get; set; } = null!;

    public Account Account { get; set; } = null!;
    public Guid? AccountId { get; set; }

}
