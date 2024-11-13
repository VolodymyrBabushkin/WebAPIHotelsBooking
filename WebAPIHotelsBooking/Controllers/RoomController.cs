using Microsoft.AspNetCore.Mvc;
using WebAPIHotelsBooking.BusinessLogic.Contracts;
using WebAPIHotelsBooking.BusinessLogic.Dtos;
using WebAPIHotelsBooking.Models.Rooms;

namespace WebAPIHotelsBooking.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly ILogger<RoomController> _logger;
        private readonly IRoomService _roomService;

        public RoomController(ILogger<RoomController> logger, IRoomService roomService)
        {
            _logger = logger;
            _roomService = roomService;
        }

        [HttpGet("get", Name = "GetRooms")]
        public async Task<ActionResult<IEnumerable<RoomDto>>> GetRooms()
        {
            try
            {
                var result = await _roomService.Get();
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Failed to fetch rooms");
                return BadRequest();
            }
        }

        [HttpGet("getById/{id}", Name = "GetRoomById")]
        public async Task<ActionResult<RoomDto>> GetRoomById([FromRoute] string id)
        {
            try
            {
                var result = await _roomService.Get(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Failed to fetch room by id");
                return BadRequest();
            }
        }

        [HttpGet("getByHotelId/{id}", Name = "GetRoomsByHotelId")]
        public async Task<ActionResult<RoomDto>> GetHotelsByCountry([FromRoute] string id)
        {
            try
            {
                var result = await _roomService.GetByHotelId(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Failed to fetch rooms by hotel id");
                return BadRequest();
            }
        }

        [HttpGet("getByBedsCount/{bedsCount}", Name = "GetHotelsByBedsCount")]
        public async Task<ActionResult<RoomDto>> GetHotelsByBedsCount([FromRoute] int bedsCount)
        {
            try
            {
                var result = await _roomService.GetByBedsCount(bedsCount);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Failed to fetch rooms by beds count");
                return BadRequest();
            }
        }

        [HttpGet("undo", Name = "Undo")]
        public async Task<ActionResult<RoomDto>> Undo()
        {
            try
            {
                await _roomService.Undo();
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Failed to undo last command");
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateRoomRequest request)
        {
            var entity = new RoomDto(
                id: Guid.NewGuid().ToString(),
                hotelId: request.HotelId,
                roomNumber: request.RoomNumber,
                bedsCount: request.BedsCount,
                freeWiFi: request.FreeWiFi);
            try
            {
                await _roomService.Create(entity);
                _logger.LogInformation($"Room with id={entity.Id} successfully created");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to create room with id={entity.Id}");
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateRoomRequest request)
        {
            var entity = new RoomDto(
                id: request.Id,
                hotelId: request.HotelId,
                roomNumber: request.RoomNumber,
                bedsCount: request.BedsCount,
                freeWiFi: request.FreeWiFi);
            try
            {
                await _roomService.Update(entity);
                _logger.LogInformation($"Room with id={entity.Id} successfully updated");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to update room with id={entity.Id}");
                return BadRequest();
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Remove(string id)
        {
            try
            {
                await _roomService.Remove(id);
                _logger.LogInformation($"Room with id={id} successfully deleted");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to delete room with id={id}");
                return BadRequest();
            }
        }
    }
}
