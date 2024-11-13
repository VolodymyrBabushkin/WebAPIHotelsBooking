using WebAPIHotelsBooking.BusinessLogic.Dtos;

namespace WebAPIHotelsBooking.BusinessLogic.Memento
{
    public class ClientsListMemento : IMemento<List<ClientDto>>
    {
        private readonly List<ClientDto> _state;
        private readonly DateTime _date;

        public ClientsListMemento(List<ClientDto> state)
        {
            _state = state;
            _date = DateTime.Now;
        }

        public DateTime GetDate()
        {
            return _date;
        }

        public List<ClientDto> GetState()
        {
            return _state;
        }
    }
}
