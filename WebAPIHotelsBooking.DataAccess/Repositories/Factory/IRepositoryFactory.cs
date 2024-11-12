using WebAPIHotelsBooking.DataAccess.Entities;

namespace WebAPIHotelsBooking.DataAccess.Repositories.Factory
{
    public interface IRepositoryFactory
    {
        IRepository<T> Instantiate<T>(HotelsBookingContext context) where T : BaseEntity;
    }
}
