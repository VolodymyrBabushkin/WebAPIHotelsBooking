using WebAPIHotelsBooking.BusinessLogic.Contracts;
using WebAPIHotelsBooking.BusinessLogic.Dtos;
using WebAPIHotelsBooking.DataAccess;
using WebAPIHotelsBooking.DataAccess.Entities;
using WebAPIHotelsBooking.DataAccess.Repositories;
using WebAPIHotelsBooking.DataAccess.Repositories.Factory;

namespace WebAPIHotelsBooking.BusinessLogic.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRepository<RoomEntity> _roomRepository;

        public RoomService(HotelsBookingContext context)
        {
            IRepositoryFactory factory = RepositoryFactory.Instance();
            _roomRepository = (RoomRepository)factory.Instantiate<RoomEntity>(context);
        }

        public async Task Create(RoomDto room)
        {
            if (room == RoomDto.Default)
                return;

            await _roomRepository.Create(new RoomEntity
            {
                Id = room.Id,
                HotelId = room.HotelId,
                RoomNumber = room.RoomNumber,
                BedsCount = room.BedsCount,
                FreeWiFi = room.FreeWiFi,
            });
        }

        public async Task<IReadOnlyList<RoomDto>> Get()
        {
            var rooms = await _roomRepository.Get();
            if (rooms == null)
                return new List<RoomDto>();

            return rooms.Select(e => new RoomDto(
                id: e.Id,
                hotelId: e.HotelId,
                roomNumber: e.RoomNumber,
                bedsCount: e.BedsCount,
                freeWiFi: e.FreeWiFi)).ToList().AsReadOnly();
        }

        public async Task<RoomDto> Get(string id)
        {
            var room = await _roomRepository.Get(id);
            if (room == null)
                return RoomDto.Default;

            return new RoomDto(
                id: room.Id,
                hotelId: room.HotelId,
                roomNumber: room.RoomNumber,
                bedsCount: room.BedsCount,
                freeWiFi: room.FreeWiFi);
        }

        public async Task<IReadOnlyList<RoomDto>> GetByBedsCount(int bedsCount)
        {
            var hotels = await _roomRepository.Get(r => r.BedsCount == bedsCount);
            if (hotels == null)
                return new List<RoomDto>();

            return hotels.Select(e => new RoomDto(
                e.Id,
                e.HotelId,
                e.RoomNumber,
                e.BedsCount,
                e.FreeWiFi)).ToList().AsReadOnly();
        }

        public async Task<IReadOnlyList<RoomDto>> GetByHotelId(string hotelId)
        {
            var hotels = await _roomRepository.Get(r => r.HotelId == hotelId);
            if (hotels == null)
                return new List<RoomDto>();

            return hotels.Select(e => new RoomDto(
                e.Id,
                e.HotelId,
                e.RoomNumber,
                e.BedsCount,
                e.FreeWiFi)).ToList().AsReadOnly();
        }

        public async Task Remove(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException();

            await _roomRepository.Delete(id);
        }

        public async Task Update(RoomDto room)
        {
            if (room == RoomDto.Default)
                return;

            await _roomRepository.Update(new RoomEntity
            {
                Id = room.Id,
                HotelId = room.HotelId,
                RoomNumber = room.RoomNumber,
                BedsCount = room.BedsCount,
                FreeWiFi = room.FreeWiFi,
            });
        }
    }
}
