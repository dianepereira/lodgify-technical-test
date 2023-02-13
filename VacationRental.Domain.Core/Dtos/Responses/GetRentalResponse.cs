using VacationRental.Domain.Core.Entities;

namespace VacationRental.Domain.Core.Dtos.Responses
{
    public class GetRentalResponse
    {
        public int Id { get; set; }
        public int Units { get; set; }
        public int PreparationTimeInDays { get; set; }

        public static GetRentalResponse From(Rental entitie)
        {
            return new GetRentalResponse
            {
                Id = entitie.Id,
                Units = entitie.Units,
                PreparationTimeInDays = entitie.PreparationTimeInDays
            };
        }
    }
}
