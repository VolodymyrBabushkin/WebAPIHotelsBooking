using System.Collections.ObjectModel;
using WebAPIHotelsBooking.DataAccess.Entities;

namespace WebAPIHotelsBooking.DataAccess.Repositories.Client
{
    public interface IClientRepository
    {
        public Task<ReadOnlyCollection<ClientEntity>> Get();
        public Task<ClientEntity?> Get(string id);
        public Task<ReadOnlyCollection<ClientEntity>> Get(Func<ClientEntity, bool> predicate);
        public Task Create(ClientEntity entity);
        public Task Update(ClientEntity entity);
        public Task Delete(string id);
    }
}
