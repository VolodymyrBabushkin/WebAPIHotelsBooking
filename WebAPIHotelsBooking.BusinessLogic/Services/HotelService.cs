using WebAPIHotelsBooking.BusinessLogic.Contracts;
using WebAPIHotelsBooking.BusinessLogic.Dtos;
using WebAPIHotelsBooking.DataAccess;
using WebAPIHotelsBooking.DataAccess.Entities;
using WebAPIHotelsBooking.DataAccess.Repositories;
using WebAPIHotelsBooking.DataAccess.Repositories.Factory;

namespace WebAPIHotelsBooking.BusinessLogic.Services
{
    public class HotelService : IHotelService
    {
        private readonly IRepository<HotelEntity> _hotelRepository;

        public HotelService(HotelsBookingContext context)
        {
            IRepositoryFactory factory = RepositoryFactory.Instance();
            _hotelRepository = (HotelRepository)factory.Instantiate<HotelEntity>(context);
        }

        public async Task Create(HotelDto hotel)
        {
            if (hotel == HotelDto.Default)
                return;

            await _hotelRepository.Create(new HotelEntity
            {
                Id = hotel.Id,
                Name = hotel.Name,
                Rating = hotel.Rating,
                Country = hotel.Country,
                City = hotel.City,
                Address = hotel.Address,
            });
        }

        public async Task<IReadOnlyList<HotelDto>> Get()
        {
            var hotels = await _hotelRepository.Get();
            if (hotels == null)
                return new List<HotelDto>();

            return hotels.Select(e => new HotelDto(
                id: e.Id,
                name: e.Name,
                rating: e.Rating,
                country: e.Country,
                city: e.City,
                address: e.Address)).ToList().AsReadOnly();
        }

        public async Task<HotelDto> Get(string id)
        {
            var hotel = await _hotelRepository.Get(id);
            if (hotel == null)
                return HotelDto.Default;

            return new HotelDto(
                id: hotel.Id,
                name: hotel.Name,
                rating: hotel.Rating,
                country: hotel.Country,
                city: hotel.City,
                address: hotel.Address);
        }

        public async Task<IReadOnlyList<HotelDto>> GetByCity(string city)
        {
            var hotels = await _hotelRepository.Get(h => h.City == city);
            if (hotels == null)
                return new List<HotelDto>();

            return hotels.Select(e => new HotelDto(
                e.Id,
                e.Name,
                e.Rating,
                e.Country,
                e.City,
                e.Address)).ToList().AsReadOnly();
        }

        public async Task<IReadOnlyList<HotelDto>> GetByCountry(string country)
        {
            var hotels = await _hotelRepository.Get(h => h.Country == country);
            if (hotels == null)
                return new List<HotelDto>();

            return hotels.Select(e => new HotelDto(
                e.Id,
                e.Name,
                e.Rating,
                e.Country,
                e.City,
                e.Address)).ToList().AsReadOnly();
        }

        public async Task Remove(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException();

            await _hotelRepository.Delete(id);
        }

        public async Task Update(HotelDto hotel)
        {
            if (hotel == HotelDto.Default)
                return;

            await _hotelRepository.Update(new HotelEntity
            {
                Id = hotel.Id,
                Name = hotel.Name,
                Rating = hotel.Rating,
                Country = hotel.Country,
                City = hotel.City,
                Address = hotel.Address,
            });
        }
    }
}
