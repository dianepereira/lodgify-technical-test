using FluentValidation.Results;

namespace VacationRental.Domain.Core.Exceptions
{
    [Serializable]
    public class ValidationException : Exception
    {
        private readonly ValidationResult _validationResult;

        public ValidationException(ValidationResult validationResult) 
            : base($"Validation error") 
        { 
            _validationResult = validationResult;    
        }
    }
}
