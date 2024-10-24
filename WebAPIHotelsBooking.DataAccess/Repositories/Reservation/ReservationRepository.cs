using System.Collections.ObjectModel;
using WebAPIHotelsBooking.DataAccess.Entities;

namespace WebAPIHotelsBooking.DataAccess.Repositories.Reservation
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly HotelsBookingContext _context;

        public ReservationRepository(HotelsBookingContext context)
        {
            _context = context;
        }

        public Task Create(ReservationEntity entity)
        {
            _context.Reservations.Add(entity);
            return Task.CompletedTask;
        }

        public Task Delete(string id)
        {
            var entity = _context.Reservations.FirstOrDefault(e => e.Id == id);
            if (entity != null)
            {
                _context.Reservations.Remove(entity);
            }
            return Task.CompletedTask;
        }

        public Task<ReadOnlyCollection<ReservationEntity>> Get()
        {
            return Task.FromResult(_context.Reservations.ToList().AsReadOnly());
        }

        public Task<ReservationEntity?> Get(string id)
        {
            return Task.FromResult(_context.Reservations.FirstOrDefault(e => e.Id == id));
        }

        public Task<ReadOnlyCollection<ReservationEntity>> Get(Func<ReservationEntity, bool> predicate)
        {
            return Task.FromResult(_context.Reservations.Where(predicate).ToList().AsReadOnly());
        }

        public Task Update(ReservationEntity entity)
        {
            foreach (var e in _context.Reservations)
            {
                if (e.Id == entity.Id)
                {
                    e.ClientId = entity.ClientId;
                    e.RoomId = entity.RoomId;
                    e.Begin = entity.Begin;
                    e.End = entity.End;
                }
            }
            return Task.CompletedTask;
        }
    }
}
