using FluentValidation;

namespace VacationRental.Domain.Commands.CreateBooking
{
    public class CreateBookingCommandValidator : AbstractValidator<CreateBookingCommand>
    {
        public CreateBookingCommandValidator()         
        {
            RuleFor(v => v)
                .NotNull();

            RuleFor(v => v.RentalId)
                .GreaterThan(0)
                .WithMessage($"Invalid RentalId property");

            RuleFor(v => v.Nights)
                .GreaterThan(0)
                .WithMessage($"Invalid Nights property");

            RuleFor(v => v.Units)
                .GreaterThan(0)
                .WithMessage("Invalid Units property");

            RuleFor(v => v.Start)
                .Must(date => date != default(DateTime))
                .WithMessage($"Date must be valid");
        }
    }
}
