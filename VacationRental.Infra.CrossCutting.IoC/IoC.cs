using Microsoft.Extensions.DependencyInjection;
using VacationRental.Infra.CrossCutting.IoC.Modules;

namespace VacationRental.Infra.CrossCutting.IoC
{
    public static class IoC
    {
        public static IServiceCollection ConfigureContainer(this IServiceCollection services)
            => services.RegisterDomain().RegisterData();
    }
}
