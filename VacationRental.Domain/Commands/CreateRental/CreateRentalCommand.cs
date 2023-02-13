using MediatR;
using VacationRental.Domain.Core.Dtos.Responses;

namespace VacationRental.Domain.Commands.CreateRental
{
    public class CreateRentalCommand : IRequest<CreateRentalResponse>
    {
        public int Units { get; set; }  
        public int PreparationTimeInDays { get; set; }  

        public CreateRentalCommand(int units, int preparationTimeInDays)
        {
            Units = units;
            PreparationTimeInDays = preparationTimeInDays;
        }   
    }
}
