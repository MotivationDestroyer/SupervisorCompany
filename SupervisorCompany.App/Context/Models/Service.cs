using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupervisorCompany.App.Context.Models;

public class Service
{
    public decimal Amount { get; set; }

    public Contract Contract { get; set; } = null!;
    public decimal Cost => Amount * ServiceType.Cost;

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public ServiceType ServiceType { get; set; } = null!;
}