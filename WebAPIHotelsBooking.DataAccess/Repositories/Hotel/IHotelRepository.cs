using System.Collections.ObjectModel;
using WebAPIHotelsBooking.DataAccess.Entities;

namespace WebAPIHotelsBooking.DataAccess.Repositories.Hotel
{
    public interface IHotelRepository
    {
        public Task<ReadOnlyCollection<HotelEntity>> Get();
        public Task<HotelEntity?> Get(string id);
        public Task<ReadOnlyCollection<HotelEntity>> Get(Func<HotelEntity, bool> predicate);
        public Task Create(HotelEntity entity);
        public Task Update(HotelEntity entity);
        public Task Delete(string id);
    }
}
