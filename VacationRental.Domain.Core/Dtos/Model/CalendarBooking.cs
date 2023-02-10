namespace VacationRental.Domain.Core.Dtos.Model
{
    public class CalendarBooking
    {
        public int Id { get; set; }
        public int Unit { get; set; }   

        public CalendarBooking(int id, int unit)
        {
            Id = id;
            Unit = unit;
        }   
    }
}
