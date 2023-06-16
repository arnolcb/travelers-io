using AutoMapper;
using si730pc2u20201b338.API.Input;
using si730pc2u20201b338.Infrastructure.Models;

namespace si730pc2u20201b338.API.Mapper;

public class InputToModel : Profile
{
    public InputToModel()
    {
        CreateMap<DestinationInput, Destination>();
    }
}