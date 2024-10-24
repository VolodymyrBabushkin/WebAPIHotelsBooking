using Microsoft.Extensions.DependencyInjection;
using WebAPIHotelsBooking.DataAccess.Repositories.Client;
using WebAPIHotelsBooking.DataAccess.Repositories.Hotel;
using WebAPIHotelsBooking.DataAccess.Repositories.Reservation;
using WebAPIHotelsBooking.DataAccess.Repositories.Room;

namespace WebAPIHotelsBooking.DataAccess.Installers
{
    public static class DataInstaller
    {
        public static IServiceCollection AddDataContext(this IServiceCollection services)
        {
            services
                .AddSingleton<HotelsBookingContext>()
                .AddTransient<IClientRepository, ClientRepository>()
                .AddTransient<IHotelRepository, HotelRepository>()
                .AddTransient<IReservationRepository, ReservationRepository>()
                .AddTransient<IRoomRepository, RoomRepository>();

            return services;
        }
    }
}
