using MediatR;
using VacationRental.Domain.Core.Dtos.Responses;

namespace VacationRental.Domain.Queries.GetBooking
{
    public  class GetBookingCommand : IRequest<GetBookingResponse>
    {
        public int Id { get; set; } 

        public GetBookingCommand(int id)
        {
            Id = id;
        }   
    }
}
