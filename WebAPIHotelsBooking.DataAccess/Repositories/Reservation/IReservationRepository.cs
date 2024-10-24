using System.Collections.ObjectModel;
using WebAPIHotelsBooking.DataAccess.Entities;

namespace WebAPIHotelsBooking.DataAccess.Repositories.Reservation
{
    public interface IReservationRepository
    {
        public Task<ReadOnlyCollection<ReservationEntity>> Get();
        public Task<ReservationEntity?> Get(string id);
        public Task<ReadOnlyCollection<ReservationEntity>> Get(Func<ReservationEntity, bool> predicate);
        public Task Create(ReservationEntity entity);
        public Task Update(ReservationEntity entity);
        public Task Delete(string id);
    }
}
