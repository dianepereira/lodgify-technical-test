using System.Net;

namespace VacationRental.Domain.Core.Exceptions
{
    public class RentalBookingNotFoundException : DomainException
    {
        public RentalBookingNotFoundException(int bookingId) : base($"There is no booking for this rental. BookingId : {bookingId}", HttpStatusCode.NotFound) { }
    }
}
