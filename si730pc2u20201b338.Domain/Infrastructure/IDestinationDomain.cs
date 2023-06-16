using si730pc2u20201b338.Infrastructure.Models;

namespace si730pc2u20201b338.Domain.Infrastructure;

public interface IDestinationDomain
{
    public Destination Create(Destination destination);
}