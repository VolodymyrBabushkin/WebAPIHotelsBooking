namespace WebAPIHotelsBooking.DataAccess.Entities
{
    public class ReservationEntity
    {
        public string Id { get; init; }
        public string ClientId { get; set; }
        public string RoomId { get; set; }
        public string Begin { get; set; }
        public string End { get; set; }
    }
}
