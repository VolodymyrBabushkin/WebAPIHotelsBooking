using System.ComponentModel.DataAnnotations;

namespace WebAPIHotelsBooking.Models.Rooms
{
    public class CreateRoomRequest
    {
        [Required]
        public string HotelId { get; init; }
        [Required]
        public int RoomNumber { get; init; }
        [Required]
        public int BedsCount { get; init; }
        [Required]
        public bool FreeWiFi { get; init; }
    }
}
