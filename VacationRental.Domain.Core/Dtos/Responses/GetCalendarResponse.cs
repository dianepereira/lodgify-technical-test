using VacationRental.Domain.Core.Dtos.Model;

namespace VacationRental.Domain.Core.Dtos.Responses
{
    public class GetCalendarResponse
    {
        public int RentalId { get; set; }   
        public List<CalendarDate> Dates { get; set; }
    }
}
