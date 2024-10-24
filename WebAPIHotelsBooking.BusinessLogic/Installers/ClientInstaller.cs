using Microsoft.Extensions.DependencyInjection;
using WebAPIHotelsBooking.BusinessLogic.Contracts;
using WebAPIHotelsBooking.BusinessLogic.Services;

namespace WebAPIHotelsBooking.BusinessLogic.Installers
{
    public static class ClientInstaller
    {
        public static IServiceCollection AddClients(this IServiceCollection services)
        {
            services.AddScoped<IClientService, ClientService>();
            return services;
        }
    }
}
