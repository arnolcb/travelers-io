using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using si730pc2u20201b338.API.Input;
using si730pc2u20201b338.API.Response;
using si730pc2u20201b338.Domain.Exception;
using si730pc2u20201b338.Domain.Infrastructure;
using si730pc2u20201b338.Infrastructure.Models;

namespace si730pc2u20201b338.API.Controllers
{
    [Route("api/v1/destinations")]
    [ApiController]
    public class DestinationController : ControllerBase
    {
        //Inject IDestinationDomain
        IDestinationDomain _destinationDomain;
        IMapper _mapper;
        
        public DestinationController(IDestinationDomain destinationDomain, IMapper mapper)
        {
            _destinationDomain = destinationDomain;
            _mapper = mapper;
        }

        // POST: api/Destination
        [HttpPost]
        public ActionResult<DestinationResponse> Post([FromBody] DestinationInput destinationInput)
        {
            Destination destination = _mapper.Map<DestinationInput, Destination>(destinationInput);
            try
            {
                _destinationDomain.Create(destination);
                DestinationResponse destinationResponse = _mapper.Map<Destination, DestinationResponse>(destination);
                return Created("", destinationResponse);
            }
            catch (DestinationException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message); 
            }
        }
    }
}
