namespace WebAPIHotelsBooking.BusinessLogic.Adapters
{
    public interface IHotelsAdapter
    {
        IEnumerable<HotelModel> Get();
    }
}
