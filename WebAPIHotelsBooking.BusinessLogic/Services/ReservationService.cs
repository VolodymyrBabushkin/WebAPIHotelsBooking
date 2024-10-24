using WebAPIHotelsBooking.BusinessLogic.Contracts;
using WebAPIHotelsBooking.BusinessLogic.Dtos;
using WebAPIHotelsBooking.DataAccess.Entities;
using WebAPIHotelsBooking.DataAccess.Repositories.Reservation;

namespace WebAPIHotelsBooking.BusinessLogic.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task Create(ReservationDto reservation)
        {
            if (reservation == ReservationDto.Default)
                return;

            await _reservationRepository.Create(new ReservationEntity
            {
                Id = reservation.Id,
                ClientId = reservation.ClientId,
                RoomId = reservation.RoomId,
                Begin = reservation.Begin,
                End = reservation.End,
            });
        }

        public async Task<IReadOnlyList<ReservationDto>> Get()
        {
            var reservations = await _reservationRepository.Get();
            if (reservations == null)
                return new List<ReservationDto>();

            return reservations.Select(e => new ReservationDto(
                id: e.Id,
                clientId: e.ClientId,
                roomId: e.RoomId,
                begin: e.Begin,
                end: e.End)).ToList().AsReadOnly();
        }

        public async Task<ReservationDto> Get(string id)
        {
            var reservation = await _reservationRepository.Get(id);
            if (reservation == null)
                return ReservationDto.Default;

            return new ReservationDto(
                id: reservation.Id,
                clientId: reservation.ClientId,
                roomId: reservation.RoomId,
                begin: reservation.Begin,
                end: reservation.End);
        }

        public async Task<IReadOnlyList<ReservationDto>> GetByClientId(string clientId)
        {
            var hotels = await _reservationRepository.Get(r => r.ClientId == clientId);
            if (hotels == null)
                return new List<ReservationDto>();

            return hotels.Select(e => new ReservationDto(
                e.Id,
                e.ClientId,
                e.RoomId,
                e.Begin,
                e.End)).ToList().AsReadOnly();
        }

        public async Task<IReadOnlyList<ReservationDto>> GetByRoomId(string roomId)
        {
            var hotels = await _reservationRepository.Get(r => r.RoomId == roomId);
            if (hotels == null)
                return new List<ReservationDto>();

            return hotels.Select(e => new ReservationDto(
                e.Id,
                e.ClientId,
                e.RoomId,
                e.Begin,
                e.End)).ToList().AsReadOnly();
        }

        public async Task Remove(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException();

            await _reservationRepository.Delete(id);
        }

        public async Task Update(ReservationDto reservation)
        {
            if (reservation == ReservationDto.Default)
                return;

            await _reservationRepository.Update(new ReservationEntity
            {
                Id = reservation.Id,
                ClientId = reservation.ClientId,
                RoomId = reservation.RoomId,
                Begin = reservation.Begin,
                End = reservation.End,
            });
        }
    }
}
