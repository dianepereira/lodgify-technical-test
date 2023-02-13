using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VacationRental.Domain.Queries.GetCalendar;

namespace VacationRental.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/calendar")]
    [Produces("application/vnd.api+json")]
    [Consumes("application/vnd.api+json")]
    [ApiController]
    public class CalendarController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CalendarController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Retrieves the availability of an existing rental unit
        /// </summary>
        /// <response code="200">Retrieve a calendar rental</response>
        /// <response code="404">There are no calendar rental to retrieve</response>
        /// <response code="500">Internal error when retrieving a calendar rental</response>
        /// <param name="rentalId"></param>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([FromQuery] int rentalId, [FromQuery] DateTime start, [FromQuery]int nights)
            => Ok( await _mediator.Send(new GetCalendarQuery(rentalId, start, nights)));
    }
}
