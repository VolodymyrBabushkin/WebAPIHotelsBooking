using Microsoft.Extensions.DependencyInjection;
using WebAPIHotelsBooking.DataAccess.Entities;
using WebAPIHotelsBooking.DataAccess.Repositories;

namespace WebAPIHotelsBooking.DataAccess.Installers
{
    public static class DataInstaller
    {
        public static IServiceCollection AddDataContext(this IServiceCollection services)
        {
            services
                .AddSingleton<HotelsBookingContext>()
                .AddTransient<IRepository<ClientEntity>, ClientRepository>()
                .AddTransient<IRepository<HotelEntity>, HotelRepository>()
                .AddTransient<IRepository<ReservationEntity>, ReservationRepository>()
                .AddTransient<IRepository<RoomEntity>, RoomRepository>();

            return services;
        }
    }
}
