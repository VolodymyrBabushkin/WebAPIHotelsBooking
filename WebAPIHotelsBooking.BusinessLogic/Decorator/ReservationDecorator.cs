using WebAPIHotelsBooking.BusinessLogic.Contracts;
using WebAPIHotelsBooking.BusinessLogic.Dtos;

namespace WebAPIHotelsBooking.BusinessLogic.Decorator
{
    public class ReservationDecorator : IReservation
    {
        protected IReservation _reservation;

        public ReservationDecorator(IReservation reservation)
        {
            _reservation = reservation;
        }

        public virtual void Create(ReservationDto reservation, IReservationService service)
        {
            _reservation.Create(reservation, service);
        }
    }
}
