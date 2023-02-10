using MediatR;
using VacationRental.Domain.Core.Dtos.Responses;

namespace VacationRental.Domain.Queries.GetCalendar
{
    public  class GetCalendarCommand : IRequest<GetCalendarResponse>
    {
        public int RentalId { get; set; }
        public DateTime Start { get; set; } 
        public int Nights { get; set; } 

        public GetCalendarCommand(int rentalId, DateTime start, int nights)
        {
            RentalId = rentalId;
            Start = start;
            Nights = nights;
        }   
    }
}
