using FluentValidation.Results;
using System.Net;

namespace VacationRental.Domain.Core.Exceptions
{
    [Serializable]
    public class ValidationException : DomainException
    {
        public ValidationException(ValidationResult validationResult) : base($"Validation error", HttpStatusCode.UnprocessableEntity)  { }
    }
}
