using WebAPIHotelsBooking.BusinessLogic.Contracts;
using WebAPIHotelsBooking.BusinessLogic.Dtos;
using WebAPIHotelsBooking.DataAccess.Entities;
using WebAPIHotelsBooking.DataAccess.Repositories.Client;

namespace WebAPIHotelsBooking.BusinessLogic.Services
{
    public  class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task Create(ClientDto client)
        {
            if (client == ClientDto.Default)
                return;

            await _clientRepository.Create(new ClientEntity
            {
                Id = client.Id,
                FirstName = client.FirstName,
                LastName = client.LastName,
            });
        }

        public async Task<IReadOnlyList<ClientDto>> Get()
        {
            var clients = await _clientRepository.Get();
            if (clients == null)
                return new List<ClientDto>();

            return clients.Select(e => new ClientDto(
                id: e.Id,
                firstName: e.FirstName,
                lastName: e.LastName)).ToList().AsReadOnly();
        }

        public async Task<ClientDto> Get(string id)
        {
            var client = await _clientRepository.Get(id);
            if (client == null)
                return ClientDto.Default;

            return new ClientDto(
                id: client.Id,
                firstName: client.FirstName,
                lastName: client.LastName);
        }

        public async Task Remove(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException();

            await _clientRepository.Delete(id);
        }

        public async Task Update(ClientDto client)
        {
            if (client == ClientDto.Default)
                return;

            await _clientRepository.Update(new ClientEntity
            {
                Id = client.Id,
                FirstName = client.FirstName,
                LastName = client.LastName,
            });
        }
    }
}
