using VacationRental.Domain.Core.Dtos.Model;

namespace VacationRental.Domain.Core.Dtos.Responses
{
    public class CreateBookingResponse
    {
        public int Id { get; set; }
        public static CreateBookingResponse From(int bookingId)
        {
            return new CreateBookingResponse
            {
                Id = bookingId
            };
        }

    }
}
