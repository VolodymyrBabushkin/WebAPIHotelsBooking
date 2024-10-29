using WebAPIHotelsBooking.DataAccess.Entities;
using WebAPIHotelsBooking.Infrastructure.Exceptions;

namespace WebAPIHotelsBooking.DataAccess.Repositories.Factory
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private static IRepositoryFactory? _instance;
        private static readonly object Locker = new();

        private RepositoryFactory() { }

        public static IRepositoryFactory Instance()
        {
            if (_instance == null)
            {
                lock (Locker)
                {
                    _instance ??= new RepositoryFactory();
                }
            }

            return _instance;
        }

        public IRepository<T> Instantiate<T>(HotelsBookingContext context) where T : BaseEntity
        {
            return typeof(T).Name switch
            {
                nameof(ClientEntity) => (IRepository<T>)new ClientRepository(context),
                nameof(HotelEntity) => (IRepository<T>)new HotelRepository(context),
                nameof(ReservationEntity) => (IRepository<T>)new ReservationRepository(context),
                nameof(RoomEntity) => (IRepository<T>)new RoomRepository(context),
                _ => throw new UnsupportedRepositoryTypeException(typeof(T).Name),
            };
        }
    }
}
