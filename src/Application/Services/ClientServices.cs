using Application.Interfaces;
using Application.Models;
using Application.Models.Request;
using Domain;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public IEnumerable<ClientDTO> GetAllClients()
        {
            var objs = _clientRepository.GetAll();
            return ClientDTO.CreateList(objs);
        }

        public ClientDTO GetClientById(int id)
        {
            var obj = _clientRepository.GetById(id);
            return ClientDTO.Create(obj);
        }

        public void CreateClient(ClientCreateRequest clientCreteRequest)
        {
            var client = new Client(clientCreteRequest.Name, clientCreteRequest.LastName, clientCreteRequest.Email, clientCreteRequest.Username, clientCreteRequest.Password);
            _clientRepository.Add(client);
        }

        public void UpdateClient(int id, ClientUpdateRequest clientUpdateRequest)
        {
            var client = _clientRepository.GetById(id);
            if (clientUpdateRequest.Name != string.Empty) client.Name = clientUpdateRequest.Name;

            if (clientUpdateRequest.Email != string.Empty) client.Email = clientUpdateRequest.Email;

            if (clientUpdateRequest.Password != string.Empty) client.Password = clientUpdateRequest.Password;

            if (clientUpdateRequest.Username != string.Empty) client.Username = clientUpdateRequest.Username;

            if (clientUpdateRequest.LastName != string.Empty) client.LastName = clientUpdateRequest.LastName;

            _clientRepository.Update(client);
        }

        public void DeleteClient(int id)
        {
            var client = _clientRepository.GetById(id);
            if (client == null)
            {
                throw new NotFoundException(nameof(Client), id);
            }
            _clientRepository.Delete(client);
        }

    }
}
