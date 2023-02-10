using MediatR;
using VacationRental.Domain.Core.Dtos.Responses;

namespace VacationRental.Domain.Queries.GetBooking
{
    public class GetBookingHandler : IRequestHandler<GetBookingCommand, GetBookingResponse>
    {
        public GetBookingHandler() { }

        public Task<GetBookingResponse> Handle(GetBookingCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
