using WebAPIHotelsBooking.BusinessLogic.Dtos;

namespace WebAPIHotelsBooking.BusinessLogic.Contracts
{
    public interface IReservationService
    {
        public Task<IReadOnlyList<ReservationDto>> Get();
        public Task<ReservationDto> Get(string id);
        public Task<IReadOnlyList<ReservationDto>> GetByClientId(string clientId);
        public Task<IReadOnlyList<ReservationDto>> GetByRoomId(string roomId);
        public Task Create(ReservationDto reservation);
        public Task Update(ReservationDto reservation);
        public Task Remove(string id);
    }
}
