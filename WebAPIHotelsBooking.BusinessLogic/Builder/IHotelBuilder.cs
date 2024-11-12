using WebAPIHotelsBooking.BusinessLogic.Dtos;

namespace WebAPIHotelsBooking.BusinessLogic.Builder
{
    public interface IHotelBuilder
    {
        IHotelBuilder SetId(string id);
        IHotelBuilder SetName(string name);
        IHotelBuilder SetRating(float rating);
        IHotelBuilder SetCountry(string country);
        IHotelBuilder SetCity(string city);
        IHotelBuilder SetAddress(string address);
        HotelDto Build();
    }
}
