namespace VacationRental.Domain.Core.Dtos.Model
{
    public class CalendarBooking : BaseDomain
    {
        public int Unit { get; set; }   

        public CalendarBooking(int id, int unit) : base()
        {
            Id = id;
            Unit = unit;
        }

        public CalendarBooking(){}

        public static CalendarBooking Create(int id, int unit)
        {
            return new CalendarBooking(id, unit);
        }
    }
}
