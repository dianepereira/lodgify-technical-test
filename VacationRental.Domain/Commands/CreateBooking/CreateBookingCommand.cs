using MediatR;
using VacationRental.Domain.Core.Dtos.Responses;

namespace VacationRental.Domain.Commands.CreateBooking
{
    public class CreateBookingCommand : IRequest<CreateBookingResponse>
    {
        public int RentalId { get; set; }
        public DateTime Start { get; set; }
        public int Nights { get; set; }
        public int Units { get; set; } 

        public CreateBookingCommand(int rentalId, DateTime start, int nights, int units)
        {
            RentalId = rentalId;
            Start = start;
            Nights = nights;
            Units = units;  
        }
    }
}
