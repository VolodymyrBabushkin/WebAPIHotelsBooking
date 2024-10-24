using System.ComponentModel.DataAnnotations;

namespace WebAPIHotelsBooking.Models.Reservations
{
    public class UpdateReservationRequest
    {
        [Required]
        public string Id { get; init; }
        [Required]
        public string ClientId { get; init; }
        [Required]
        public string RoomId { get; init; }
        [Required]
        public string Begin { get; init; }
        [Required]
        public string End { get; init; }
    }
}
