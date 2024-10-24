using System.Collections.ObjectModel;
using WebAPIHotelsBooking.DataAccess.Entities;

namespace WebAPIHotelsBooking.DataAccess.Repositories.Client
{
    public class ClientRepository : IClientRepository
    {
        private readonly HotelsBookingContext _context;

        public ClientRepository(HotelsBookingContext context)
        {
            _context = context;
        }

        public Task Create(ClientEntity entity)
        {
            _context.Clients.Add(entity);
            return Task.CompletedTask;
        }

        public Task Delete(string id)
        {
            var entity = _context.Clients.FirstOrDefault(e => e.Id == id);
            if (entity != null)
            {
                _context.Clients.Remove(entity);
            }
            return Task.CompletedTask;
        }

        public Task<ReadOnlyCollection<ClientEntity>> Get()
        {
            return Task.FromResult(_context.Clients.ToList().AsReadOnly());
        }

        public Task<ClientEntity?> Get(string id)
        {
            return Task.FromResult(_context.Clients.FirstOrDefault(e => e.Id == id));
        }

        public Task<ReadOnlyCollection<ClientEntity>> Get(Func<ClientEntity, bool> predicate)
        {
            return Task.FromResult(_context.Clients.Where(predicate).ToList().AsReadOnly());
        }

        public Task Update(ClientEntity entity)
        {
            foreach (var e in _context.Clients)
            {
                if (e.Id == entity.Id)
                {
                    e.FirstName = entity.FirstName;
                    e.LastName = entity.LastName;
                }
            }
            return Task.CompletedTask;
        }
    }
}
