using WebAPIHotelsBooking.BusinessLogic.Dtos;

namespace WebAPIHotelsBooking.BusinessLogic.Contracts
{
    public interface IHotelService
    {
        Task<IReadOnlyList<HotelDto>> Get();
        Task<HotelDto> Get(string id);
        Task<IReadOnlyList<HotelDto>> GetByCountry(string country);
        Task<IReadOnlyList<HotelDto>> GetByCity(string city);
        Task Create(HotelDto hotel);
        Task Update(HotelDto hotel);
        Task Remove(string id);
    }
}
