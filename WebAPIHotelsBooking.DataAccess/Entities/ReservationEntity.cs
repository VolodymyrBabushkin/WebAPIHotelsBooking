namespace WebAPIHotelsBooking.DataAccess.Entities
{
    public class ReservationEntity : BaseEntity
    {
        public string ClientId { get; set; }
        public string RoomId { get; set; }
        public string Begin { get; set; }
        public string End { get; set; }

        public override object Clone()
        {
            ReservationEntity clone = (ReservationEntity)base.Clone();
            clone.ClientId = ClientId;
            clone.RoomId = RoomId;
            clone.Begin = Begin;
            clone.End = End;
            return clone;
        }
    }
}
