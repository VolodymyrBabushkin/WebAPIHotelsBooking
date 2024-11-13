using Microsoft.Extensions.DependencyInjection;
using WebAPIHotelsBooking.BusinessLogic.Contracts;
using WebAPIHotelsBooking.BusinessLogic.Services;
using WebAPIHotelsBooking.BusinessLogic.Services.Proxy;

namespace WebAPIHotelsBooking.BusinessLogic.Installers
{
    public static class ClientInstaller
    {
        public static IServiceCollection AddClients(this IServiceCollection services)
        {
            services.AddSingleton<ClientService>();
            services.AddSingleton<IClientService, ClientServiceProxy>();
            return services;
        }
    }
}
