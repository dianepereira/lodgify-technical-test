namespace VacationRental.Domain.Core.Exceptions
{
    [Serializable]
    public class RentalNotFoundException : Exception
    {
        public RentalNotFoundException() { }

        public RentalNotFoundException(int rentalId) : base($"Rental was not found. RentalId : {rentalId}") { }
    }
}
