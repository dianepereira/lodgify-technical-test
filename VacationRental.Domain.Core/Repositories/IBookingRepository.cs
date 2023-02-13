using VacationRental.Domain.Core.Entities;

namespace VacationRental.Domain.Core.Repositories
{
    public interface IBookingRepository : IRepository<Booking>
    {
        IEnumerable<Booking> GetBookingByRentalId(int rentalId);
        bool IsBookingAvaiable(int rentalId, int preparationTime, int rentalUnits, int bookingUnits, DateTime start, int nights);
    }
}
