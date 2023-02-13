using VacationRental.Domain.Core.Dtos.Model;

namespace VacationRental.Domain.Core.Entities
{
    public class Rental : BaseDomain
    {
        public int Units { get; private set; }
        public int PreparationTimeInDays { get; private set; }


        public Rental(int units, int preparationTimeInDays) : base()
        { 
            Units= units;   
            PreparationTimeInDays= preparationTimeInDays;   
        }

        public static Rental Create(int units, int preparationTimeInDays)
        { 
            return new Rental(units, preparationTimeInDays);
        }
    }
}
