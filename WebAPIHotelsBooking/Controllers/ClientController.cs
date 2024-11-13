using Microsoft.AspNetCore.Mvc;
using WebAPIHotelsBooking.BusinessLogic.Contracts;
using WebAPIHotelsBooking.BusinessLogic.Decorator;
using WebAPIHotelsBooking.BusinessLogic.Dtos;
using WebAPIHotelsBooking.BusinessLogic.Memento;
using WebAPIHotelsBooking.BusinessLogic.Services;
using WebAPIHotelsBooking.DataAccess.Entities;
using WebAPIHotelsBooking.Models.Clients;
using WebAPIHotelsBooking.Models.Reservations;

namespace WebAPIHotelsBooking.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;
        private readonly IClientService _clientService;

        public ClientController(ILogger<ClientController> logger, IClientService accountService)
        {
            _logger = logger;
            _clientService = accountService;
        }

        [HttpGet("get", Name = "GetClients")]
        public async Task<ActionResult<IEnumerable<ClientDto>>> GetClients()
        {
            try
            {
                var result = await _clientService.Get();
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Failed to fetch clients");
                return BadRequest();
            }
        }

        [HttpGet("getById/{id}", Name = "GetClientById")]
        public async Task<ActionResult<ClientDto>> GetClientById([FromRoute] string id)
        {
            try
            {
                var result = await _clientService.Get(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Failed to fetch client by id");
                return BadRequest();
            }
        }

        [HttpPost("mementoTest", Name = "MementoTest")]
        public void MementoTest()
        {
            ClientsList clients = new ClientsList();
            clients.Add(new ClientDto("1", "Axel", "Van de Velde"));
            clients.Add(new ClientDto("2", "Gordan", "Laydel"));
            ClientsListCaretaker caretaker = new ClientsListCaretaker(clients);

            Console.WriteLine("Before changes:");
            foreach (var client in clients.GetClients())
            {
                Console.WriteLine($"    {client.Id}: {client.FirstName} {client.LastName}");
            }

            caretaker.Backup();
            clients.Add(new ClientDto("3", "Axel", "Laydel"));

            caretaker.Backup();
            clients.RemoveAt(1);

            Console.WriteLine("After changes:");
            foreach (var client in clients.GetClients())
            {
                Console.WriteLine($"    {client.Id}: {client.FirstName} {client.LastName}");
            }

            caretaker.Undo();
            Console.WriteLine("First undo:");
            foreach (var client in clients.GetClients())
            {
                Console.WriteLine($"    {client.Id}: {client.FirstName} {client.LastName}");
            }

            caretaker.Undo();
            Console.WriteLine("Second undo:");
            foreach (var client in clients.GetClients())
            {
                Console.WriteLine($"    {client.Id}: {client.FirstName} {client.LastName}");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateClientRequest request)
        {
            var entity = new ClientDto(
                id: Guid.NewGuid().ToString(),
                firstName: request.FirstName,
                lastName: request.LastName);
            try
            {
                await _clientService.Create(entity);
                _logger.LogInformation($"Client with id={entity.Id} successfully created");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to create client with id={entity.Id}");
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateClientRequest request)
        {
            var entity = new ClientDto(
                id: request.Id,
                firstName: request.FirstName,
                lastName: request.LastName);
            try
            {
                await _clientService.Update(entity);
                _logger.LogInformation($"Client with id={entity.Id} successfully updated");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to update client with id={entity.Id}");
                return BadRequest();
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Remove(string id)
        {
            try
            {
                await _clientService.Remove(id);
                _logger.LogInformation($"Client with id={id} successfully deleted");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to delete client with id={id}");
                return BadRequest();
            }
        }
    }
}
