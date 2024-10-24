using System.ComponentModel.DataAnnotations;

namespace WebAPIHotelsBooking.Models.Clients
{
    public class UpdateClientRequest
    {
        [Required]
        public string Id { get; init; }
        [Required]
        public string FirstName { get; init; }
        [Required]
        public string LastName { get; init; }
    }
}
