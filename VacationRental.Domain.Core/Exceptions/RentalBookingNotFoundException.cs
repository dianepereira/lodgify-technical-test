using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationRental.Domain.Core.Exceptions
{
    public class RentalBookingNotFoundException : Exception
    {
        public RentalBookingNotFoundException() { }

        public RentalBookingNotFoundException(int bookingId) : base($"There is no booking for this rental. BookingId : {bookingId}") { }

    }
}
