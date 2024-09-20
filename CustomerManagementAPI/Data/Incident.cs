using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerManagementAPI.Data;

public class Incident
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public string IncidentName { get; set; } = null!;

    [Required]
    public string Description { get; set; } = null!;

    public ICollection<Account> Accounts { get; set; } = null!;
}
