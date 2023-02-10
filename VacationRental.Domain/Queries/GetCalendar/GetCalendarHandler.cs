using MediatR;
using VacationRental.Domain.Core.Dtos.Responses;

namespace VacationRental.Domain.Queries.GetCalendar
{
    public  class GetCalendarHandler : IRequestHandler<GetCalendarCommand, GetCalendarResponse>
    {
        public GetCalendarHandler() { }

        public Task<GetCalendarResponse> Handle(GetCalendarCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
