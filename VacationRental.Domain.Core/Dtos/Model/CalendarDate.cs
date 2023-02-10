namespace VacationRental.Domain.Core.Dtos.Model
{
    public class CalendarDate
    {
        public DateTime Date { get; set; }
        public List<CalendarBooking> Bookings { get; set; } 
        public List<PreparationTime> PreparationTime { get; set; }

        public CalendarDate(DateTime date)
        {
            Date = date;
            Bookings = new List<CalendarBooking>();   
            PreparationTime = new List<PreparationTime>();  
        }
    }
}
