using System.Net;

namespace VacationRental.Domain.Core.Exceptions
{
    [Serializable]
    public class RentalNotFoundException : DomainException
    {
        public RentalNotFoundException(int rentalId) : base($"Rental was not found. RentalId : {rentalId}", HttpStatusCode.NotFound) { }
    }
}
