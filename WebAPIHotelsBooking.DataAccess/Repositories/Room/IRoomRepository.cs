using System.Collections.ObjectModel;
using WebAPIHotelsBooking.DataAccess.Entities;

namespace WebAPIHotelsBooking.DataAccess.Repositories.Room
{
    public interface IRoomRepository
    {
        public Task<ReadOnlyCollection<RoomEntity>> Get();
        public Task<RoomEntity?> Get(string id);
        public Task<ReadOnlyCollection<RoomEntity>> Get(Func<RoomEntity, bool> predicate);
        public Task Create(RoomEntity entity);
        public Task Update(RoomEntity entity);
        public Task Delete(string id);
    }
}
