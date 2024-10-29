namespace WebAPIHotelsBooking.DataAccess.Entities
{
    public class RoomEntity : BaseEntity
    {
        public string HotelId { get; set; }
        public int RoomNumber { get; set; }
        public int BedsCount { get; set; }
        public bool FreeWiFi { get; set; }
    }
}
