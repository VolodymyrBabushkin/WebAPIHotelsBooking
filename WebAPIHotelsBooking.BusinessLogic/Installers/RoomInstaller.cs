using Microsoft.Extensions.DependencyInjection;
using WebAPIHotelsBooking.BusinessLogic.Contracts;
using WebAPIHotelsBooking.BusinessLogic.Services;

namespace WebAPIHotelsBooking.BusinessLogic.Installers
{
    public static class RoomInstaller
    {
        public static IServiceCollection AddRooms(this IServiceCollection services)
        {
            services.AddScoped<IRoomService, RoomService>();
            return services;
        }
    }
}
