using MediatR;
using VacationRental.Domain.Core.Dtos.Responses;
using VacationRental.Domain.Core.Exceptions;
using VacationRental.Domain.Core.Repositories;

namespace VacationRental.Domain.Queries.GetBooking
{
    public class GetBookingQueryHandler : IRequestHandler<GetBookingQuery, GetBookingResponse>
    {
        private readonly IBookingRepository _bookingRepository;

        public GetBookingQueryHandler(IBookingRepository bookingRepository) 
        { 
            _bookingRepository = bookingRepository;
        }

        public Task<GetBookingResponse> Handle(GetBookingQuery request, CancellationToken cancellationToken)
        {
            var booking = _bookingRepository.Get(request.Id);

            if (booking == null)
                throw new RentalBookingNotFoundException(request.Id);

            return Task.FromResult(GetBookingResponse.From(booking));
        }
    }
}
