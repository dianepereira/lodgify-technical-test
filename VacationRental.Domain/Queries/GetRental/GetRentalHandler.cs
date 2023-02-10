using MediatR;
using VacationRental.Domain.Core.Dtos.Responses;

namespace VacationRental.Domain.Queries.GetRental
{
    public class GetRentalHandler : IRequestHandler<GetRentalCommand, GetRentalResponse>
    {
        public GetRentalHandler() { }

        public Task<GetRentalResponse> Handle(GetRentalCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
