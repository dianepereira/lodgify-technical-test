namespace VacationRental.Domain.Core.Exceptions
{
    [Serializable]
    public class RentalBookingNotAvaiableException : Exception
    {
        public RentalBookingNotAvaiableException() { }

        public RentalBookingNotAvaiableException(int rentalId) : base($"Rental is not avaiable to the rentalId: {rentalId}") { }  
    }
}
