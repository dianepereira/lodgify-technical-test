using VacationRental.Domain.Core.Dtos.Model;

namespace VacationRental.Domain.Core.Entities
{
    public class Booking : BaseDomain
    {
        public int RentalId { get; private set; }
        public DateTime Start { get; private set; }
        public int Nights { get; private set; }
        public int Units { get; private set; }

        private Booking(int rentalId, DateTime start, int nights, int units) : base()
        {
            RentalId = rentalId;
            Start = start;
            Nights = nights;
            Units = units;
        }

        public static Booking Create(int rentalId, DateTime start, int nights, int units)
        {
            return new Booking(rentalId, start, nights, units);
        }
    }
}
