using MediatR;
using Microsoft.Extensions.DependencyInjection;
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
            => services.AddCommandHandlers().AddQueriesHandlers();


        private static IServiceCollection AddCommandHandlers(this IServiceCollection services) => services
            .AddScoped<IRequestHandler<CreateRentalCommand, CreateRentalResponse>, CreateRentalHandler>()
            .AddScoped<IRequestHandler<CreateBookingCommand, CreateBookingResponse>, CreateBookingHandler>();

        private static IServiceCollection AddQueriesHandlers(this IServiceCollection services) => services
            .AddScoped<IRequestHandler<GetRentalCommand, GetRentalResponse>, GetRentalHandler>()
            .AddScoped<IRequestHandler<GetBookingCommand, GetBookingResponse>, GetBookingHandler>()
            .AddScoped<IRequestHandler<GetCalendarCommand, GetCalendarResponse>, GetCalendarHandler>();
    }
}
