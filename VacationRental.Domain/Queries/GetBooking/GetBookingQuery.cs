using MediatR;
using VacationRental.Domain.Core.Dtos.Responses;

namespace VacationRental.Domain.Queries.GetBooking
{
    public  class GetBookingQuery : IRequest<GetBookingResponse>
    {
        public int Id { get; set; } 

        public GetBookingQuery(int id)
        {
            Id = id;
        }   
    }
}
