﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerManagementAPI.Models;

public class Incident
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public string IncidentName { get; set; } = null!;

    [Required]
    public string Description { get; set; } = null!;

    [Required]
    public required ICollection<Account> Accounts { get; set; }
}
