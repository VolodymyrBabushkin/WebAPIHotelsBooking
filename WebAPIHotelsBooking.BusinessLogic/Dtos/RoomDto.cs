namespace WebAPIHotelsBooking.BusinessLogic.Dtos
{
    public class RoomDto : IEquatable<RoomDto>
    {
        public static readonly RoomDto Default = new RoomDto(string.Empty, string.Empty, 0, 0, false);

        public string Id { get; }
        public string HotelId { get; }
        public int RoomNumber { get; }
        public int BedsCount { get; }
        public bool FreeWiFi { get; }

        public RoomDto(string id, string hotelId, int roomNumber, int bedsCount, bool freeWiFi)
        {
            Id = id;
            HotelId = hotelId;
            RoomNumber = roomNumber;
            BedsCount = bedsCount;
            FreeWiFi = freeWiFi;
        }

        public bool Equals(RoomDto? other)
        {
            if (other == null)
                return false;

            return Id == other.Id && HotelId == other.HotelId && RoomNumber == other.RoomNumber 
                && BedsCount == other.BedsCount && FreeWiFi == other.FreeWiFi;
        }

        public override int GetHashCode()
        {
            return (Id.GetHashCode().ToString() + HotelId.GetHashCode() + RoomNumber.GetHashCode() 
                + BedsCount.GetHashCode() + FreeWiFi.GetHashCode()).GetHashCode();
        }
    }
}
