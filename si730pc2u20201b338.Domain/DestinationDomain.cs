using si730pc2u20201b338.Domain.Exception;
using si730pc2u20201b338.Domain.Infrastructure;
using si730pc2u20201b338.Infrastructure.Infrastructure;
using si730pc2u20201b338.Infrastructure.Models;

namespace si730pc2u20201b338.Domain;

public class DestinationDomain : IDestinationDomain
{
    IDestinationInfrastructure _destinationInfrastructure;
    
    public DestinationDomain(IDestinationInfrastructure destinationInfrastructure)
    {
        _destinationInfrastructure = destinationInfrastructure;
    }
    
    public Destination Create(Destination destination)
    {
        //Validamos
        DestinationValidation(destination);
        //Guardamos (Creamos)
        _destinationInfrastructure.Create(destination);
        return destination;
    }
    
    //Validations
    private void DestinationValidation(Destination destination)
    {
        if (destination.Name == null)
        {
            throw new DestinationException("Name es obligatorio");
        }
        if (destination.maxUsers <= 0)
        {
            throw new DestinationException("maxUsers no puede ser menor o igual a 0");
        }
        if (destination.isRisky != 0 && destination.isRisky != 1)
        {
            throw new DestinationException("isRisky solo puede ser 0 o 1");
        }
        if (_destinationInfrastructure.ExistsByName(destination.Name))
        {
            throw new DestinationException("Ya existe un destination con ese nombre");
        }
    }
}