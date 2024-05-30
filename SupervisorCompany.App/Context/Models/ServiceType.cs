using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupervisorCompany.App.Context.Models;

public class ServiceType
{
    public decimal Cost { get; set; }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public bool IsDividable { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<Service> Services { get; set; } = new List<Service>();
    public string Unit { get; set; } = null!;
}