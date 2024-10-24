using WebAPIHotelsBooking.BusinessLogic.Dtos;

namespace WebAPIHotelsBooking.BusinessLogic.Contracts
{
    public interface IRoomService
    {
        Task<IReadOnlyList<RoomDto>> Get();
        Task<RoomDto> Get(string id);
        Task<IReadOnlyList<RoomDto>> GetByHotelId(string hotelId);
        Task<IReadOnlyList<RoomDto>> GetByBedsCount(int bedsCount);
        Task Create(RoomDto room);
        Task Update(RoomDto room);
        Task Remove(string id);
    }
}
