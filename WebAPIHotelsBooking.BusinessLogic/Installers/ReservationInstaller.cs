using Microsoft.Extensions.DependencyInjection;
using WebAPIHotelsBooking.BusinessLogic.Contracts;
using WebAPIHotelsBooking.BusinessLogic.Services;

namespace WebAPIHotelsBooking.BusinessLogic.Installers
{
    public static class ReservationInstaller
    {
        public static IServiceCollection AddReservations(this IServiceCollection services)
        {
            services.AddScoped<IReservationService, ReservationService>();
            return services;
        }
    }
}
