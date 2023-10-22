using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using VacationRental.Domain.Commands.CreateBooking;
using VacationRental.Domain.Commands.CreateRental;
using VacationRental.Domain.Core.Repositories;
using VacationRental.Infra.Data.Repositories;

namespace VacationRental.Infra.CrossCutting.IoC.Modules
{
    public static class DataModule
    {
        public static IServiceCollection RegisterData(this IServiceCollection services)
            => services.AddRepositories();

        public static IServiceCollection AddRepositories(this IServiceCollection services) => services
          .AddSingleton(typeof(IRepository<>), typeof(Repository<>))
          .AddSingleton(typeof(IBookingRepository), typeof(BookingRepository));

    }
}
