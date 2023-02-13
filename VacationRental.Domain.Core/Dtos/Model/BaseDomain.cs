namespace VacationRental.Domain.Core.Dtos.Model
{
    public class BaseDomain
    {
        public int Id { get; set; }

        protected BaseDomain()
        { 
            Id = 0;         
        }
    }
}
