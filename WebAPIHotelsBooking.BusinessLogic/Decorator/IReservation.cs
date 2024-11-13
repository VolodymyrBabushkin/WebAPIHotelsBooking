using WebAPIHotelsBooking.BusinessLogic.Contracts;
using WebAPIHotelsBooking.BusinessLogic.Dtos;

namespace WebAPIHotelsBooking.BusinessLogic.Decorator
{
    public interface IReservation
    {
        public void Create(ReservationDto reservation, IReservationService service);
    }
}
