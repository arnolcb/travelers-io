using si730pc2u20201b338.Infrastructure.Models;
using si730pc2u20201b338.Infrastructure.Context;

namespace si730pc2u20201b338.Infrastructure.Infrastructure;

public interface IDestinationInfrastructure
{
    public Destination Create(Destination destination);
    public Boolean ExistsByName(string name);
}