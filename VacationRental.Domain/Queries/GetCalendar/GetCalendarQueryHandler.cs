using MediatR;
using VacationRental.Domain.Core.Dtos.Model;
using VacationRental.Domain.Core.Dtos.Responses;
using VacationRental.Domain.Core.Entities;
using VacationRental.Domain.Core.Exceptions;
using VacationRental.Domain.Core.Repositories;

namespace VacationRental.Domain.Queries.GetCalendar
{
    public class GetCalendarQueryHandler : IRequestHandler<GetCalendarQuery, GetCalendarResponse>
    {
        private readonly IRepository<Rental> _rentalRepository;
        private readonly IBookingRepository _bookingRepository;

        public GetCalendarQueryHandler(IRepository<Rental> rentalRepository,
                                  IBookingRepository bookingRepository)
        {
            _rentalRepository = rentalRepository;
            _bookingRepository = bookingRepository;
        }

        public Task<GetCalendarResponse> Handle(GetCalendarQuery request, CancellationToken cancellationToken)
        {
            var rental = _rentalRepository.Get(request.RentalId);

            if (rental == null)
                throw new RentalNotFoundException(request.RentalId);

            var response = new GetCalendarResponse { RentalId = rental.Id };
            response.Dates = new List<CalendarDate>();

            var bookings = _bookingRepository.GetBookingByRentalId(rental.Id);

            for (var i = 0; i < request.Nights; i++)
            {
                var date = new CalendarDate(request.Start.Date.AddDays(i));

                foreach (var booking in bookings)
                {
                    date.AddBookings(booking);
                    date.AddPreparationTime(booking, rental.PreparationTimeInDays);
                }

                response.Dates.Add(date);
            }

            return Task.FromResult(response);
        }
    }
}
