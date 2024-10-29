using System.Collections.ObjectModel;
using WebAPIHotelsBooking.DataAccess.Entities;

namespace WebAPIHotelsBooking.DataAccess.Repositories
{
    public class HotelRepository : IRepository<HotelEntity>
    {
        private readonly HotelsBookingContext _context;

        public HotelRepository(HotelsBookingContext context)
        {
            _context = context;
        }

        public Task Create(HotelEntity entity)
        {
            _context.Hotels.Add(entity);
            return Task.CompletedTask;
        }

        public Task Delete(string id)
        {
            var entity = _context.Hotels.FirstOrDefault(e => e.Id == id);
            if (entity != null)
            {
                _context.Hotels.Remove(entity);
            }
            return Task.CompletedTask;
        }

        public Task<ReadOnlyCollection<HotelEntity>> Get()
        {
            return Task.FromResult(_context.Hotels.ToList().AsReadOnly());
        }

        public Task<HotelEntity?> Get(string id)
        {
            return Task.FromResult(_context.Hotels.FirstOrDefault(e => e.Id == id));
        }

        public Task<ReadOnlyCollection<HotelEntity>> Get(Func<HotelEntity, bool> predicate)
        {
            return Task.FromResult(_context.Hotels.Where(predicate).ToList().AsReadOnly());
        }

        public Task Update(HotelEntity entity)
        {
            foreach (var e in _context.Hotels)
            {
                if (e.Id == entity.Id)
                {
                    e.Name = entity.Name;
                    e.Rating = entity.Rating;
                    e.Country = entity.Country;
                    e.City = entity.City;
                    e.Address = entity.Address;
                }
            }
            return Task.CompletedTask;
        }
    }
}
