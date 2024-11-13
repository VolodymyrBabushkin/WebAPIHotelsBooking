using WebAPIHotelsBooking.BusinessLogic.Dtos;
using WebAPIHotelsBooking.Infrastructure.Exceptions;

namespace WebAPIHotelsBooking.BusinessLogic.Memento
{
    public class ClientsList
    {
        private List<ClientDto> _clients = new List<ClientDto>();

        public List<ClientDto> GetClients()
        {
            return _clients;
        }

        public void Add(ClientDto client)
        {
            _clients.Add(client);
        }

        public void RemoveAt(int index)
        {
            _clients.RemoveAt(index);
        }

        public IMemento<List<ClientDto>> Save()
        {
            return new ClientsListMemento(new List<ClientDto>(_clients));
        }

        public void Restore(IMemento<List<ClientDto>> memento)
        {
            if (!(memento is ClientsListMemento))
            {
                throw new UnknownMementoClassException();
            }

            _clients = memento.GetState();
        }
    }
}
