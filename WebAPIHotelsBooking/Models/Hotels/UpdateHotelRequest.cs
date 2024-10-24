using System.ComponentModel.DataAnnotations;

namespace WebAPIHotelsBooking.Models.Hotels
{
    public class UpdateHotelRequest
    {
        [Required]
        public string Id { get; init; }
        [Required]
        public string Name { get; init; }
        [Required]
        public float Rating { get; init; }
        [Required]
        public string Country { get; init; }
        [Required]
        public string City { get; init; }
        [Required]
        public string Address { get; init; }
    }
}
