using WebAPIHotelsBooking.BusinessLogic.Dtos;

namespace WebAPIHotelsBooking.BusinessLogic.Contracts
{
    public interface IClientService
    {
        Task<IReadOnlyList<ClientDto>> Get();
        Task<ClientDto> Get(string id);
        Task Create(ClientDto client);
        Task Update(ClientDto client);
        Task Remove(string id);
    }
}