using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupervisorCompany.App.Context.Models;

public class Contract
{
    public string Description { get; set; } = null!;
    public DateTimeOffset EndDate { get; set; }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public Person Person { get; set; } = null!;
    public ICollection<Service> Services { get; set; } = new List<Service>();
    public DateTimeOffset StartDate { get; set; }

    public decimal TotalCost => Services.Sum(s => s.Cost);
}