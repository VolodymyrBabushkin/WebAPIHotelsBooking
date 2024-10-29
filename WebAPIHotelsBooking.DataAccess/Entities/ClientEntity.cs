namespace WebAPIHotelsBooking.DataAccess.Entities
{
    public class ClientEntity : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override object Clone()
        {
            ClientEntity clone = (ClientEntity)base.Clone();
            clone.FirstName = FirstName;
            clone.LastName = LastName;
            return clone;
        }
    }
}
