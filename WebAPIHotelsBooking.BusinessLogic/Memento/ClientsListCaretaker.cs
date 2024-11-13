using Microsoft.Extensions.Logging;
using WebAPIHotelsBooking.BusinessLogic.Dtos;

namespace WebAPIHotelsBooking.BusinessLogic.Memento
{
    public class ClientsListCaretaker
    {
        private List<IMemento<List<ClientDto>>> _mementos = new List<IMemento<List<ClientDto>>>();
        private ClientsList _originator;

        public ClientsListCaretaker(ClientsList originator)
        {
            _originator = originator;
        }

        public void Backup()
        {
            _mementos.Add(_originator.Save());
        }

        public void Undo()
        {
            if (_mementos.Count == 0) return;

            var memento = _mementos.Last();
            _mementos.Remove(memento);

            _originator.Restore(memento);
        }
    }
}
