namespace WebAPIHotelsBooking.BusinessLogic.Dtos
{
    public class ReservationDto : IEquatable<ReservationDto>
    {
        public static readonly ReservationDto Default
            = new ReservationDto(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);

        public string Id { get; }
        public string ClientId { get; }
        public string RoomId { get; }
        public string Begin { get; }
        public string End { get; }

        public ReservationDto(string id, string clientId, string roomId, string begin, string end)
        {
            Id = id;
            ClientId = clientId;
            RoomId = roomId;
            Begin = begin;
            End = end;
        }

        public bool Equals(ReservationDto? other)
        {
            if (other == null)
                return false;

            return Id == other.Id && ClientId == other.ClientId && RoomId == other.RoomId && Begin == other.Begin && End == other.End;
        }

        public override int GetHashCode()
        {
            return (Id.GetHashCode().ToString() + ClientId.GetHashCode() + RoomId.GetHashCode()
                + Begin.GetHashCode() + End.GetHashCode()).GetHashCode();
        }
    }
}
