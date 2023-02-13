using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using VacationRental.Domain.Commands.CreateBooking;
using VacationRental.Domain.Core.Dtos.Requests;
using VacationRental.Domain.Queries.GetBooking;

namespace VacationRental.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/bookings")]
    [Produces("application/vnd.api+json")]
    [Consumes("application/vnd.api+json")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IMediator _mediator;


        public BookingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Retrieves the booking information for a rental
        /// </summary>
        /// <response code="200">Retrieve a booking for rental</response>
        /// <response code="404">There are no booking to retrieve</response>
        /// <response code="500">Internal error when retrieving a booking</response>
        /// <param name="rentalId"></param>
        [HttpGet("{bookingId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([FromRoute] int bookingId)
            => Ok(await _mediator.Send(new GetBookingQuery(bookingId)));

        /// <summary>
        /// Create the the booking for a rental
        /// </summary>
        /// <response code="200">Create a booking</response>
        /// <response code="422">Invalid booking</response>
        /// <response code="500">Internal error when creating a booking</response>
        /// <param name="rentalId"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CreateBookingRequest request)
            => StatusCode((int)HttpStatusCode.Created, await _mediator.Send(new CreateBookingCommand(request.RentalId, request.Start, request.Nights, request.Units)));
    }
}
