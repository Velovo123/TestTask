using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerManagementAPI.Models;

public class Incident
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public string IncidentName { get; set; } = null!;

    [StringLength(500, ErrorMessage = "Description can't be longer than 500 characters.")]
    public string Description { get; set; } = null!;

    public required ICollection<Account> Accounts { get; set; }
}
