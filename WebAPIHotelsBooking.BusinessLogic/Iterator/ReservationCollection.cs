using System.Collections;
using System.ComponentModel;
using WebAPIHotelsBooking.BusinessLogic.Dtos;

namespace WebAPIHotelsBooking.BusinessLogic.Iterator
{
    public class ReservationCollection : IEnumerable<ReservationDto>
    {
        private List<ReservationDto> _reservations = new List<ReservationDto>();

        public void Add(ReservationDto reservation)
        {
            _reservations.Add(reservation);
        }

        public IEnumerator<ReservationDto> GetEnumerator()
        {
            return new ReservationEnumerator(_reservations);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
