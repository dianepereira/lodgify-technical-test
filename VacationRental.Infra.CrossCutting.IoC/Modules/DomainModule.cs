using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using VacationRental.Domain.Behaviors;
using VacationRental.Domain.Commands.CreateBooking;
using VacationRental.Domain.Commands.CreateRental;
using VacationRental.Domain.Core.Dtos.Responses;
using VacationRental.Domain.Queries.GetBooking;
using VacationRental.Domain.Queries.GetCalendar;
using VacationRental.Domain.Queries.GetRental;

namespace VacationRental.Infra.CrossCutting.IoC.Modules
{
    public static class DomainModule
    {
        public static IServiceCollection RegisterDomain(this IServiceCollection services)
            => services.AddCommandBehaviors().AddCommandHandlers().AddQueriesHandlers().AddCommandValidators();

        private static IServiceCollection AddCommandBehaviors(this IServiceCollection services) => services
            .AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));

        private static IServiceCollection AddCommandHandlers(this IServiceCollection services) => services
            .AddScoped<IRequestHandler<CreateRentalCommand, CreateRentalResponse>, CreateRentalCommandHandler>()
            .AddScoped<IRequestHandler<CreateBookingCommand, CreateBookingResponse>, CreateBookingCommandHandler>();

        private static IServiceCollection AddQueriesHandlers(this IServiceCollection services) => services
            .AddScoped<IRequestHandler<GetRentalQuery, GetRentalResponse>, GetRentalQueryHandler>()
            .AddScoped<IRequestHandler<GetBookingQuery, GetBookingResponse>, GetBookingQueryHandler>()
            .AddScoped<IRequestHandler<GetCalendarQuery, GetCalendarResponse>, GetCalendarQueryHandler>();

        public static IServiceCollection AddCommandValidators(this IServiceCollection services) => services
            .AddScoped<IValidator<CreateBookingCommand>, CreateBookingCommandValidator>()
            .AddScoped<IValidator<CreateRentalCommand>, CreateRentalCommandValidator>();
    }
}
