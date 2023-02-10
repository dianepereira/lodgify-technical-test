using MediatR;
using VacationRental.Domain.Core.Dtos.Responses;

namespace VacationRental.Domain.Commands.CreateBooking
{
    public class CreateBookingCommand : IRequest<CreateBookingResponse>
    {
        public int RentalId { get; set; }   
        public DateTime Start { get; set; } 
        public int Nights { get; set; } 

        public CreateBookingCommand(int rentalId, DateTime start, int nights)
        {
            RentalId = rentalId;
            Start = start;
            Nights = nights;
        }
    }
}
