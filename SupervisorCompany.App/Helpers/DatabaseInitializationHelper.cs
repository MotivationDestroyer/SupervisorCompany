using SupervisorCompany.App.Context;
using SupervisorCompany.App.Context.Models;

namespace SupervisorCompany.App.Helpers;

public static class DatabaseInitializationHelper
{
    public static void InitializeDatabase(SupervisorCompanyDbContext dbContext, bool recreateFromScratch)
    {
        if (recreateFromScratch)
        {
            dbContext.Database.EnsureDeleted();
        }

        dbContext.Database.EnsureCreated();

        var person1 = new Person
        {
            FullName = "John Doe",
            PhoneNumber = "+1234567890"
        };

        person1.Addresses.Add(new Address
        {
            Apartment = "1",
            House = new House
            {
                Building = "1",
                Street = "Street1"
            }
        });

        dbContext.Add(new Contract
        {
            Description = "short description 1",
            StartDate = DateTimeOffset.Now,
            EndDate = DateTimeOffset.Now.AddDays(10),
            Person = person1,
            Services = new List<Service>
            {
                new()
                {
                    Amount = 500,
                    ServiceType = new ServiceType
                    {
                        Name = "Service Type 1",
                        Cost = .2M,
                        Unit = "grams",
                        IsDividable = true
                    }
                }
            }
        });

        dbContext.Add(new Contract
        {
            Description = "short description 2",
            StartDate = DateTimeOffset.Now,
            EndDate = DateTimeOffset.Now.AddDays(10),
            Person = person1,
            Services = new List<Service>
            {
                new()
                {
                    Amount = 2,
                    ServiceType = new ServiceType
                    {
                        Name = "Service Type 2",
                        Cost = 100.0M,
                        Unit = "pieces",
                        IsDividable = false
                    }
                }
            }
        });

        dbContext.Add(person1);

        //TODO initialize other data

        dbContext.SaveChanges();
    }
}