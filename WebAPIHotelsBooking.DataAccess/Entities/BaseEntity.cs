namespace WebAPIHotelsBooking.DataAccess.Entities
{
    public class BaseEntity : ICloneable
    {
        public string Id { get; set; }

        public virtual object Clone()
        {
            return new BaseEntity { Id = this.Id };
        }
    }
}
