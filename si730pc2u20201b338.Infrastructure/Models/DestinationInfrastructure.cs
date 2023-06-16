using si730pc2u20201b338.Infrastructure.Context;
using si730pc2u20201b338.Infrastructure.Infrastructure;

namespace si730pc2u20201b338.Infrastructure.Models;

public class DestinationInfrastructure : IDestinationInfrastructure
{
    private ProjectContext _context;
    
    public DestinationInfrastructure(ProjectContext context)
    {
        _context = context;
    }

    public Destination Create(Destination destination)
    {
        _context.Destinations.Add(destination);
        _context.SaveChanges();
        return destination;
    }

    public bool ExistsByName(string name)
    {
        return _context.Destinations.Any(p => p.Name == name);
    }
}