using MediatR;
using VacationRental.Domain.Core.Dtos.Responses;

namespace VacationRental.Domain.Queries.GetRental
{
    public  class GetRentalCommand : IRequest<GetRentalResponse>
    {
        public int Id { get; set; }

        public GetRentalCommand(int reantalId)
        {
            Id = reantalId;
        }
    }
}
