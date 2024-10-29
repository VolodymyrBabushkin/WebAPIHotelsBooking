using Microsoft.Extensions.DependencyInjection;
using WebAPIHotelsBooking.BusinessLogic.Builder;
using WebAPIHotelsBooking.BusinessLogic.Contracts;
using WebAPIHotelsBooking.BusinessLogic.Services;

namespace WebAPIHotelsBooking.BusinessLogic.Installers
{
    public static class HotelInstaller
    {
        public static IServiceCollection AddHotels(this IServiceCollection services)
        {
            services.AddScoped<IHotelService, HotelService>()
                .AddScoped<IHotelBuilder, HotelBuilder>();
            return services;
        }
    }
}
