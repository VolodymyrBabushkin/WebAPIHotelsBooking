namespace WebAPIHotelsBooking.DataAccess.Entities
{
    public class RoomEntity
    {
        public string Id { get; init; }
        public string HotelId { get; set; }
        public int RoomNumber { get; set; }
        public int BedsCount { get; set; }
        public bool FreeWiFi { get; set; }
    }
}
