using VacationRental.Domain.Core.Entities;

namespace VacationRental.Domain.Core.Dtos.Responses
{
    public  class GetBookingResponse
    {
        public int Id { get; set; } 
        public int RentalId { get; set; }   
        public DateTime Start { get; set; } 
        public int Nights { get; set; } 

        public static GetBookingResponse From(Booking entitie)
        {
            return new GetBookingResponse
            {
                Id = entitie.Id,
                RentalId = entitie.RentalId,
                Start = entitie.Start,  
                Nights = entitie.Nights
            };
        }
    }
}
