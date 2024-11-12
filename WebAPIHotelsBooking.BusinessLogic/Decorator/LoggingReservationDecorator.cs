using Microsoft.Extensions.Logging;
using WebAPIHotelsBooking.BusinessLogic.Contracts;
using WebAPIHotelsBooking.BusinessLogic.Dtos;

namespace WebAPIHotelsBooking.BusinessLogic.Decorator
{
    public class LoggingReservationDecorator : ReservationDecorator
    {
        private readonly ILogger _logger;

        public LoggingReservationDecorator(IReservation reservation, ILogger logger) : base(reservation)
        {
            _logger = logger;
        }

        public override void Create(ReservationDto reservation, IReservationService service)
        {
            _logger.LogInformation($"[LOG]: Reservaton of room with id={reservation.Id} is being processed.");
            base.Create(reservation, service);
            _logger.LogInformation($"[LOG]: Reservaton of room with id={reservation.Id} has been processed.");
        }
    }
}
