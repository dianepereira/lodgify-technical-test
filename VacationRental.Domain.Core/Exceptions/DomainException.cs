using System.Net;

namespace VacationRental.Domain.Core.Exceptions
{
    public  class DomainException : Exception
    {
        protected DomainException(string message, HttpStatusCode statusCode = HttpStatusCode.InternalServerError) : base(message) { }
    }
}
