using SupervisorCompany.App.Context.Models;

namespace SupervisorCompany.App.Models;

public class ServiceDisplayModel
{
    public ServiceDisplayModel(Service svc)
    {
        Id = svc.Id;
        TotalCost = svc.Cost;
        ServiceName = svc.ServiceType.Name;
    }

    public string ServiceName { get; }

    public decimal TotalCost { get; }
    public long Id { get; }
}