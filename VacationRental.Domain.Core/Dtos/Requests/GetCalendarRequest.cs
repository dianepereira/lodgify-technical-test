namespace VacationRental.Domain.Core.Dtos.Requests
{
    public  class GetCalendarRequest
    {
        public int RentalId { get; set; }   
        public DateTime Start { get; set; } 
        public int Nights { get; set; } 
    }
}
