using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using VacationRental.Domain.Commands.CreateRental;
using VacationRental.Domain.Core.Dtos.Requests;
using VacationRental.Domain.Queries.GetRental;

namespace VacationRental.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/rentals")]
    [Produces("application/vnd.api+json")]
    [Consumes("application/vnd.api+json")]  
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RentalsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Retrieves the rental information
        /// </summary>
        /// <response code="200">Retrieve a rental</response>
        /// <response code="404">There are no rental to retrieve</response>
        /// <response code="500">Internal error when retrieving a rental</response>
        /// <param name="rentalId"></param>
        /// <returns></returns>
        [HttpGet("{rentalId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([FromRoute] int rentalId)
            => Ok(await _mediator.Send(new GetRentalQuery(rentalId)));

        /// <summary>
        /// Create the host rental
        /// </summary>
        /// <response code="200">Create a rental</response>
        /// <response code="422">Invalid rental</response>
        /// <response code="500">Internal error when creating a rental</response>
        /// <param name="rentalId"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CreateRentalRequest request)
            => StatusCode((int)HttpStatusCode.Created, await _mediator.Send(new CreateRentalCommand(request.Units, request.PreparationTimeInDays)));
    }
}
