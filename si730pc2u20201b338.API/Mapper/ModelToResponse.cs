using AutoMapper;
using si730pc2u20201b338.API.Response;
using si730pc2u20201b338.Infrastructure.Models;

namespace si730pc2u20201b338.API.Mapper;

public class ModelToResponse : Profile
{
    public ModelToResponse()
    {
        CreateMap<Destination, DestinationResponse>();
    }
    
}