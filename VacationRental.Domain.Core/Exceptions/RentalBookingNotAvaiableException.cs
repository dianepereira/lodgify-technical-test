using System.Net;

namespace VacationRental.Domain.Core.Exceptions
{
    [Serializable]
    public class RentalBookingNotAvaiableException : DomainException
    {
        public RentalBookingNotAvaiableException(int rentalId) : base($"Rental is not avaiable to the rentalId: {rentalId}", HttpStatusCode.NotFound) { }  
    }
}
