using MediatR;
using VacationRental.Domain.Core.Dtos.Responses;

namespace VacationRental.Domain.Queries.GetRental
{
    public  class GetRentalQuery : IRequest<GetRentalResponse>
    {
        public int Id { get; set; }

        public GetRentalQuery(int reantalId)
        {
            Id = reantalId;
        }
    }
}
