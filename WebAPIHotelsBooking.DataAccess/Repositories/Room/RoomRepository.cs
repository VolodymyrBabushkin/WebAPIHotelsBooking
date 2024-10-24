using System.Collections.ObjectModel;
using System.Linq;
using WebAPIHotelsBooking.DataAccess.Entities;

namespace WebAPIHotelsBooking.DataAccess.Repositories.Room
{
    internal class RoomRepository : IRoomRepository
    {
        private readonly HotelsBookingContext _context;

        public RoomRepository(HotelsBookingContext context)
        {
            _context = context;
        }

        public Task Create(RoomEntity entity)
        {
            _context.Rooms.Add(entity);
            return Task.CompletedTask;
        }

        public Task Delete(string id)
        {
            var entity = _context.Rooms.FirstOrDefault(e => e.Id == id);
            if (entity != null)
            {
                _context.Rooms.Remove(entity);
            }
            return Task.CompletedTask;
        }

        public Task<ReadOnlyCollection<RoomEntity>> Get()
        {
            return Task.FromResult(_context.Rooms.ToList().AsReadOnly());
        }

        public Task<RoomEntity?> Get(string id)
        {
            return Task.FromResult(_context.Rooms.FirstOrDefault(e => e.Id == id));
        }

        public Task<ReadOnlyCollection<RoomEntity>> Get(Func<RoomEntity, bool> predicate)
        {
            return Task.FromResult(_context.Rooms.Where(predicate).ToList().AsReadOnly());
        }

        public Task Update(RoomEntity entity)
        {
            foreach (var e in _context.Rooms)
            {
                if (e.Id == entity.Id)
                {
                    e.HotelId = entity.HotelId;
                    e.RoomNumber = entity.RoomNumber;
                    e.BedsCount = entity.BedsCount;
                    e.FreeWiFi = entity.FreeWiFi;
                }
            }
            return Task.CompletedTask;
        }
    }
}
