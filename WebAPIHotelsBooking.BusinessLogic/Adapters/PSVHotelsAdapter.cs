using PSVHotelsService;
using WebAPIHotelsBooking.Infrastructure.Exceptions;

namespace WebAPIHotelsBooking.BusinessLogic.Adapters
{
    public class PSVHotelsAdapter : IHotelsAdapter
    {
        private readonly IPSVHotels _hotels;

        public PSVHotelsAdapter(IPSVHotels hotels)
        {
            _hotels = hotels;
        }

        public IEnumerable<HotelModel> Get()
        {
            return _hotels.GetHotels().Select(hotel =>
            {
                var longAddress = hotel.LongAddress.Split('|');
                if (longAddress.Length != 3)
                {
                    throw new InvalidPSVHotelModelException();
                }
                return new HotelModel
                {
                    Id = hotel.Id,
                    Name = hotel.Name,
                    Rating = hotel.Rating,
                    Country = longAddress[0].Trim(),
                    City = longAddress[1].Trim(),
                    Address = longAddress[2].Trim(),
                };
            });
        }
    }
}
