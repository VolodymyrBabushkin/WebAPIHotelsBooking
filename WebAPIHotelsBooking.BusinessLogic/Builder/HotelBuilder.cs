using WebAPIHotelsBooking.BusinessLogic.Dtos;

namespace WebAPIHotelsBooking.BusinessLogic.Builder
{
    public class HotelBuilder : IHotelBuilder
    {
        private string? _id;
        private string _name;
        private float _rating;
        private string _country;
        private string _city;
        private string _address;

        public HotelDto Build()
        {
            return new HotelDto(
                id: _id ?? Guid.NewGuid().ToString(),
                name: _name,
                rating: _rating,
                country: _country,
                city: _city,
                address: _address
            );
        }

        public IHotelBuilder SetAddress(string address)
        {
            _address = address;
            return this;
        }

        public IHotelBuilder SetCity(string city)
        {
            _city = city;
            return this;
        }

        public IHotelBuilder SetCountry(string country)
        {
            _country = country;
            return this;
        }

        public IHotelBuilder SetId(string id)
        {
            _id = id;
            return this;
        }

        public IHotelBuilder SetName(string name)
        {
            _name = name;
            return this;
        }

        public IHotelBuilder SetRating(float rating)
        {
            _rating = rating;
            return this;
        }
    }
}
