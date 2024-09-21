using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerManagementAPI.Models;

public class Incident
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Required(ErrorMessage = "Incident name is required.")]
    [StringLength(50, ErrorMessage = "Incident name can't be longer than 50 characters.")]
    public string IncidentName { get; set; } = null!;

    [StringLength(500, ErrorMessage = "Description can't be longer than 500 characters.")]
    public string Description { get; set; } = null!;

    [Required(ErrorMessage = "At least one account required")]
    public required ICollection<Account> Accounts { get; set; }
}
