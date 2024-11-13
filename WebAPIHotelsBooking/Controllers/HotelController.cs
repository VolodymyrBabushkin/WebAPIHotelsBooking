using Microsoft.AspNetCore.Mvc;
using PSVHotelsService;
using WebAPIHotelsBooking.BusinessLogic.Adapters;
using WebAPIHotelsBooking.BusinessLogic.Builder;
using WebAPIHotelsBooking.BusinessLogic.Contracts;
using WebAPIHotelsBooking.BusinessLogic.Dtos;
using WebAPIHotelsBooking.Models.Hotels;

namespace WebAPIHotelsBooking.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotelController : ControllerBase
    {
        private readonly ILogger<HotelController> _logger;
        private readonly IHotelService _hotelService;
        private readonly IHotelBuilder _hotelBuilder;

        public HotelController(ILogger<HotelController> logger, IHotelService hotelService, IHotelBuilder hotelBuilder)
        {
            _logger = logger;
            _hotelService = hotelService;
            _hotelBuilder = hotelBuilder;
        }

        [HttpGet("get", Name = "GetHotels")]
        public async Task<ActionResult<IEnumerable<ReservationDto>>> GetHotels()
        {
            try
            {
                var result = await _hotelService.Get();
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Failed to fetch hotels");
                return BadRequest();
            }
        }

        [HttpGet("getById/{id}", Name = "GetHotelById")]
        public async Task<ActionResult<HotelDto>> GetHotelById([FromRoute] string id)
        {
            try
            {
                var result = await _hotelService.Get(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Failed to fetch hotel by id");
                return BadRequest();
            }
        }

        [HttpGet("getByCountry/{country}", Name = "GetHotelsByCountry")]
        public async Task<ActionResult<HotelDto>> GetHotelsByCountry([FromRoute] string country)
        {
            try
            {
                var result = await _hotelService.GetByCountry(country);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Failed to fetch hotel by country");
                return BadRequest();
            }
        }

        [HttpGet("getByCity/{city}", Name = "GetHotelsByCity")]
        public async Task<ActionResult<HotelDto>> GetHotelsByCity([FromRoute] string city)
        {
            try
            {
                var result = await _hotelService.GetByCity(city);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Failed to fetch hotel by city");
                return BadRequest();
            }
        }

        [HttpGet("getPSVHotels", Name = "GetPSVHotels")]
        public async Task<ActionResult> GetPSVHotels()
        {
            PSVHotelsAdapter hotels = new PSVHotelsAdapter(new PSVHotels());
            foreach (var hotel in hotels.Get())
            {
                var entity = _hotelBuilder
                    .SetId(hotel.Id)
                    .SetName(hotel.Name)
                    .SetRating(hotel.Rating)
                    .SetCountry(hotel.Country)
                    .SetCity(hotel.City)
                    .SetAddress(hotel.Address)
                    .Build();
                try
                {
                    await _hotelService.Create(entity);
                    _logger.LogInformation($"Hotel with id={entity.Id} succesfully loaded from PSV");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Failed to load hotel with id={entity.Id} from PSV");
                    return BadRequest();
                }
            }
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateHotelRequest request)
        {
            var entity = _hotelBuilder
                .SetName(request.Name)
                .SetRating(request.Rating)
                .SetCountry(request.Country)
                .SetCity(request.City)
                .SetAddress(request.Address)
                .Build();
            try
            {
                await _hotelService.Create(entity);
                _logger.LogInformation($"Hotel with id={entity.Id} successfully created");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to create hotel with id={entity.Id}");
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateHotelRequest request)
        {
            var entity = _hotelBuilder
                .SetId(request.Id)
                .SetName(request.Name)
                .SetRating(request.Rating)
                .SetCountry(request.Country)
                .SetCity(request.City)
                .SetAddress(request.Address)
                .Build();
            try
            {
                await _hotelService.Update(entity);
                _logger.LogInformation($"Hotel with id={entity.Id} successfully updated");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to update hotel with id={entity.Id}");
                return BadRequest();
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Remove(string id)
        {
            try
            {
                await _hotelService.Remove(id);
                _logger.LogInformation($"Hotel with id={id} successfully deleted");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to delete hotel with id={id}");
                return BadRequest();
            }
        }
    }
}
