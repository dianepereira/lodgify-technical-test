using MediatR;
using VacationRental.Domain.Core.Dtos.Responses;
using VacationRental.Domain.Core.Entities;
using VacationRental.Domain.Core.Exceptions;
using VacationRental.Domain.Core.Repositories;

namespace VacationRental.Domain.Commands.CreateBooking
{
    public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, CreateBookingResponse>
    {
        private readonly IRepository<Rental> _rentalRepository;
        private readonly IBookingRepository _bookingRepository;

        public CreateBookingCommandHandler(IRepository<Rental> rentalRepository,
                                    IBookingRepository bookingRepository) 
        {
            _rentalRepository = rentalRepository;
            _bookingRepository = bookingRepository;
        }

        public Task<CreateBookingResponse> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            var rental = _rentalRepository.Get(request.RentalId);

            if (rental == null)
                throw new RentalNotFoundException(request.RentalId);
            
            if(request.Units > rental.Units)
                throw new RentalInsuficientsUnitsException(rental.Units, request.Units);

            var bookingAvaiability = _bookingRepository.IsBookingAvaiable(rental.Id, rental.PreparationTimeInDays, rental.Units, request.Units, request.Start, request.Nights);

            if (!bookingAvaiability)
                throw new RentalBookingNotAvaiableException(rental.Id);
            
            var bookingId = _bookingRepository.Add(Booking.Create(request.RentalId, request.Start, request.Nights, request.Units)).Id;

            return Task.FromResult(CreateBookingResponse.From(bookingId));
        }
    }
}
