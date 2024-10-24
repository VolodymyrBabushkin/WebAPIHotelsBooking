namespace WebAPIHotelsBooking.BusinessLogic.Dtos
{
    public class ClientDto : IEquatable<ClientDto>
    {
        public static readonly ClientDto Default = new ClientDto(string.Empty, string.Empty, string.Empty);

        public string Id { get; }
        public string FirstName { get; }
        public string LastName { get; }

        public ClientDto(string id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public bool Equals(ClientDto? other)
        {
            if (other == null)
                return false;

            return Id == other.Id && FirstName == other.FirstName && LastName == other.LastName;

        }

        public override int GetHashCode()
        {
            return (Id.GetHashCode().ToString() + FirstName.GetHashCode() + LastName.GetHashCode()).GetHashCode();
        }
    }
}
