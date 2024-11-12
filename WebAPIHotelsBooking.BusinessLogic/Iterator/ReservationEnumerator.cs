using System.Collections;
using WebAPIHotelsBooking.BusinessLogic.Dtos;

namespace WebAPIHotelsBooking.BusinessLogic.Iterator
{
    public class ReservationEnumerator : IEnumerator<ReservationDto>
    {
        private readonly List<ReservationDto> _reservations;
        private int _position = -1;

        public ReservationEnumerator(List<ReservationDto> reservations)
        {
            _reservations = reservations;
        }

        public ReservationDto Current => _reservations[_position];

        object IEnumerator.Current => Current;

        public void Dispose() { }

        public bool MoveNext()
        {
            _position += 1;
            return _position < _reservations.Count;
        }

        public void Reset()
        {
            _position = -1;
        }
    }
}
