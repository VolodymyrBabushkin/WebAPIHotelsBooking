namespace WebAPIHotelsBooking.DataAccess.Entities
{
    public class HotelEntity : BaseEntity
    {
        public string Name { get; set; }
        public float Rating { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

        public override object Clone()
        {
            HotelEntity clone = new HotelEntity();
            clone.Id = Id;
            clone.Name = Name;
            clone.Rating = Rating;
            clone.Country = Country;
            clone.City = City;
            clone.Address = Address;
            return clone;
        }
    }
}
