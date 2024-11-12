namespace WebAPIHotelsBooking.DataAccess.Entities
{
    public class BaseEntity : ICloneable
    {
        public string Id { get; init; }

        public virtual object Clone()
        {
            return new BaseEntity { Id = this.Id };
        }
    }
}
