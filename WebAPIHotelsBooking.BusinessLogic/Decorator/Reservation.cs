using WebAPIHotelsBooking.BusinessLogic.Contracts;
using WebAPIHotelsBooking.BusinessLogic.Dtos;

namespace WebAPIHotelsBooking.BusinessLogic.Decorator
{
    public class Reservation : IReservation
    {
        public async void Create(ReservationDto reservation, IReservationService service)
        {
            await service.Create(reservation);
        }
    }
}
