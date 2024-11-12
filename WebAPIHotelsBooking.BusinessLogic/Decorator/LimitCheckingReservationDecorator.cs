using Microsoft.Extensions.Logging;
using WebAPIHotelsBooking.BusinessLogic.Contracts;
using WebAPIHotelsBooking.BusinessLogic.Dtos;

namespace WebAPIHotelsBooking.BusinessLogic.Decorator
{
    public class LimitCheckingReservationDecorator : ReservationDecorator
    {
        private readonly ILogger _logger;
        private int _daysLimit;

        public LimitCheckingReservationDecorator(IReservation reservation, int daysLimit, ILogger logger) : base(reservation)
        {
            _daysLimit = daysLimit;
            _logger = logger;
        }

        public override void Create(ReservationDto reservation, IReservationService service)
        {
            var begin = Convert.ToDateTime(reservation.Begin);
            var end = Convert.ToDateTime(reservation.End);
            if ((end - begin).TotalDays > _daysLimit)
            {
                _logger.LogError($"[ERROR]: Reservation with id={reservation.Id} of {(end - begin).TotalDays} days exceeds the limit of {_daysLimit} days");
            }
            else
            {
                base.Create(reservation, service);
            }
        }
    }
}
