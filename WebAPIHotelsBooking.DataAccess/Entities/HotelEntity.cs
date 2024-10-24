namespace WebAPIHotelsBooking.DataAccess.Entities
{
    public class HotelEntity
    {
        public string Id { get; init; }
        public string Name { get; set; }
        public float Rating { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
    }
}
