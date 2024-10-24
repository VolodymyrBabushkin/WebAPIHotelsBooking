using System.ComponentModel.DataAnnotations;

namespace WebAPIHotelsBooking.Models.Clients
{
    public class CreateClientRequest
    {
        [Required]
        public string FirstName { get; init; }
        [Required]
        public string LastName { get; init; }
    }
}
