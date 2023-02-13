using VacationRental.Domain.Core.Entities;
using VacationRental.Domain.Core.Repositories;

namespace VacationRental.Infra.Data.Repositories
{
    public class BookingRepository : Repository<Booking>, IBookingRepository
    {
        public IEnumerable<Booking> GetBookingByRentalId(int rentalId)
        {
            return _dataPersistence.Values.Where(b => b.RentalId == rentalId).OrderBy(b => b.Start).ToList();
        }

        public bool IsBookingAvaiable(int rentalId, int preparationTime, int rentalUnits, int bookingUnits, DateTime start, int nights)
        {
            bool avaiable = true;

            var rentalBookings = _dataPersistence.Values
                .Where(booking => booking.RentalId == rentalId)
                .OrderBy(booking => booking.Start);

            var avaiableBookings = rentalBookings.Where(booking =>
                         (booking.Start <= start.Date && booking.Start.AddDays(booking.Nights + preparationTime) > start.Date)
                        || (booking.Start < start.AddDays(nights + preparationTime) && booking.Start.AddDays(booking.Nights + preparationTime) >= start.AddDays(nights + preparationTime))
                        || (booking.Start > start && booking.Start.AddDays(booking.Nights + preparationTime) < start.AddDays(nights + preparationTime))).ToArray();

            if (avaiableBookings.Length >= rentalUnits)
                avaiable = false;

            return avaiable;
        }
    }
}
