using VacationRental.Domain.Core.Entities;

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

        public void AddBookings(Booking booking)
        {
            var endBookingDate = booking.Start.AddDays(booking.Nights);

            if (booking.Start <= Date && endBookingDate > Date)
            {
                Bookings.Add(CalendarBooking.Create(booking.Id, booking.Units));
            }
        }

        public void AddPreparationTime(Booking booking, int preparationTimeInDays)
        {
            var endBookingDate = booking.Start.AddDays(booking.Nights);

            if (endBookingDate <= Date && endBookingDate.AddDays(preparationTimeInDays) > Date)
            {
                PreparationTime.Add(new PreparationTime
                {
                    Unit = booking.Units
                });
            }
        }
    }
}
