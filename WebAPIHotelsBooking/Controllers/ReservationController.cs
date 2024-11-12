using Microsoft.AspNetCore.Mvc;
using WebAPIHotelsBooking.BusinessLogic.Contracts;
using WebAPIHotelsBooking.BusinessLogic.Decorator;
using WebAPIHotelsBooking.BusinessLogic.Dtos;
using WebAPIHotelsBooking.Models.Reservations;

namespace WebAPIHotelsBooking.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly ILogger<ReservationController> _logger;
        private readonly IReservationService _reservationService;

        public ReservationController(ILogger<ReservationController> logger, IReservationService reservationService)
        {
            _logger = logger;
            _reservationService = reservationService;
        }

        [HttpGet("get", Name = "GetReservations")]
        public async Task<ActionResult<IEnumerable<ReservationDto>>> GetReservations()
        {
            try
            {
                var result = await _reservationService.Get();
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Failed to fetch reservations");
                return BadRequest();
            }
        }

        [HttpGet("getById/{id}", Name = "GetReservationById")]
        public async Task<ActionResult<ReservationDto>> GetReservationById([FromRoute] string id)
        {
            try
            {
                var result = await _reservationService.Get(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Failed to fetch reservation by id");
                return BadRequest();
            }
        }

        [HttpGet("getByClientId/{clientId}", Name = "GetHotelsByClientId")]
        public async Task<ActionResult<ReservationDto>> GetHotelsByClientId([FromRoute] string clientId)
        {
            try
            {
                var result = await _reservationService.GetByClientId(clientId);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Failed to fetch reservation by client id");
                return BadRequest();
            }
        }

        [HttpGet("getByRoomId/{roomId}", Name = "GetHotelsByRoomId")]
        public async Task<ActionResult<ReservationDto>> GetHotelsByRoomId([FromRoute] string roomId)
        {
            try
            {
                var result = await _reservationService.GetByRoomId(roomId);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Failed to fetch reservation by room id");
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateReservationRequest request)
        {
            var entity = new ReservationDto(
                id: Guid.NewGuid().ToString(),
                clientId: request.ClientId,
                roomId: request.RoomId,
                begin: request.Begin,
                end: request.End);
            try
            {
                await _reservationService.Create(entity);
                _logger.LogInformation($"Reservation with id={entity.Id} successfully created");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to create reservation with id={entity.Id}");
                return BadRequest();
            }
        }

        [HttpPost("decoratorTest", Name = "DecoratorTestCreateReservation")]
        public async Task<ActionResult> CreateWithDecorator([FromBody] CreateReservationRequest request)
        {
            IReservation reservation = new Reservation();
            IReservation loggingReservation = new LoggingReservationDecorator(reservation, _logger);
            IReservation reservationWithLoggingAndLimit = new LimitCheckingReservationDecorator(loggingReservation, 5, _logger);

            var entity = new ReservationDto(
                id: Guid.NewGuid().ToString(),
                clientId: request.ClientId,
                roomId: request.RoomId,
                begin: request.Begin,
                end: request.End);

            reservationWithLoggingAndLimit.Create(entity, _reservationService);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateReservationRequest request)
        {
            var entity = new ReservationDto(
                id: request.Id,
                clientId: request.ClientId,
                roomId: request.RoomId,
                begin: request.Begin,
                end: request.End);
            try
            {
                await _reservationService.Update(entity);
                _logger.LogInformation($"Reservation with id={entity.Id} successfully updated");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to update reservation with id={entity.Id}");
                return BadRequest();
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Remove(string id)
        {
            try
            {
                await _reservationService.Remove(id);
                _logger.LogInformation($"Reservation with id={id} successfully deleted");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to delete reservation with id={id}");
                return BadRequest();
            }
        }
    }
}
