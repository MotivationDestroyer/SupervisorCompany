using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupervisorCompany.App.Context.Models;

public class Address
{
    public string Apartment { get; set; } = null!;
    public House House { get; set; } = null!;

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public Person Person { get; set; } = null!;
}