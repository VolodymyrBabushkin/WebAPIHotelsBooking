namespace WebAPIHotelsBooking.BusinessLogic.Dtos
{
    public class HotelDto : IEquatable<HotelDto>
    {
        public static readonly HotelDto Default 
            = new HotelDto(string.Empty, string.Empty, 0.0f, string.Empty, string.Empty, string.Empty);

        public string Id { get; }
        public string Name { get; }
        public float Rating { get; }
        public string Country { get; }
        public string City { get; }
        public string Address { get; }

        public HotelDto(string id, string name, float rating, string country, string city, string address)
        {
            Id = id;
            Name = name;
            Rating = rating;
            Country = country;
            City = city;
            Address = address;
        }

        public bool Equals(HotelDto? other)
        {
            if (other == null)
                return false;

            return Id == other.Id && Name == other.Name && Rating == other.Rating 
                && Country == other.Country && City == other.City && Address == other.Address;
        }

        public override int GetHashCode()
        {
            return (Id.GetHashCode().ToString() + Name.GetHashCode() + Rating.GetHashCode()
                + Country.GetHashCode() + City.GetHashCode() + Address.GetHashCode()).GetHashCode();
        }
    }
}
