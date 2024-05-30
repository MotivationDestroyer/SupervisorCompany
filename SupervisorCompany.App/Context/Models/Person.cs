using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupervisorCompany.App.Context.Models;

public class Person
{
    public ICollection<Address> Addresses { get; set; } = new List<Address>();
    public ICollection<Contract> Contracts { get; set; } = new List<Contract>();
    public string FullName { get; set; } = null!;

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public string PhoneNumber { get; set; } = null!;
}