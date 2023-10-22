using FluentValidation;

namespace VacationRental.Domain.Commands.CreateRental
{
    public class CreateRentalCommandValidator : AbstractValidator<CreateRentalCommand>
    {
        public CreateRentalCommandValidator() 
        {
            RuleFor(c => c)
                .NotNull();

            RuleFor(c => c.Units)
                .GreaterThan(0)
                .WithMessage($"Invalid Unit property");

            RuleFor(c => c.PreparationTimeInDays)
                .GreaterThanOrEqualTo(0)
                .WithMessage($"Invalid PreparationTimeInDays property");        
        }
    }
}
