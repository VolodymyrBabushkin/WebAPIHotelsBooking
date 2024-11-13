namespace WebAPIHotelsBooking.DataAccess.Entities
{
    public class RoomEntity : BaseEntity
    {
        public string HotelId { get; set; }
        public int RoomNumber { get; set; }
        public int BedsCount { get; set; }
        public bool FreeWiFi { get; set; }

        public override object Clone()
        {
            RoomEntity clone = new RoomEntity();
            clone.Id = Id;
            clone.HotelId = HotelId;
            clone.RoomNumber = RoomNumber;
            clone.BedsCount = BedsCount;
            clone.FreeWiFi = FreeWiFi;
            return clone;
        }
    }
}
