using VacationRental.Domain.Core.Dtos.Model;

namespace VacationRental.Domain.Core.Dtos.Responses
{
    public  class CreateRentalResponse
    {
        public int Id { get; set; }

        public static CreateRentalResponse From(BaseDomain entitie)
        {
            return new CreateRentalResponse
            {
                Id = entitie.Id
            };
        }
    }
}
