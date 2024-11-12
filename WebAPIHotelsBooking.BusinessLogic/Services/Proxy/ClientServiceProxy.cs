using WebAPIHotelsBooking.BusinessLogic.Contracts;
using WebAPIHotelsBooking.BusinessLogic.Dtos;

namespace WebAPIHotelsBooking.BusinessLogic.Services.Proxy
{
    public class ClientServiceProxy : IClientService
    {
        private readonly ClientService _clientService;
        private readonly Dictionary<string, ClientDto> _cache;
        private IReadOnlyList<ClientDto>? _allClientsCache;

        public ClientServiceProxy(ClientService clientService)
        {
            _clientService = clientService;
            _cache = new Dictionary<string, ClientDto>();
        }

        public async Task Create(ClientDto client)
        {
            await _clientService.Create(client);
            InvalidateCache(false);
        }

        public async Task<IReadOnlyList<ClientDto>> Get()
        {
            if (_allClientsCache != null)
            {
                return _allClientsCache;
            }

            var clients = await _clientService.Get();
            _allClientsCache = clients;
            return clients;
        }

        public async Task<ClientDto> Get(string id)
        {
            if (_cache.ContainsKey(id))
            {
                return _cache[id];
            }

            var client = await _clientService.Get(id);
            if (client != ClientDto.Default)
            {
                _cache[id] = client;
            }
            return client;
        }

        public async Task Remove(string id)
        {
            await _clientService.Remove(id);
            InvalidateCache();
        }

        public async Task Update(ClientDto client)
        {
            await _clientService.Update(client);
            InvalidateCache();
        }

        private void InvalidateCache(bool invalidateById = true)
        {
            _allClientsCache = null;

            if (invalidateById)
                _cache.Clear();
        }
    }
}
