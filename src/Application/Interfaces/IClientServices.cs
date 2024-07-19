using Application.Models;
using Application.Models.Request;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IClientService
    {
        IEnumerable<ClientDTO> GetAllClients();
        ClientDTO GetClientById(int id);
        void CreateClient(ClientCreateRequest clientCreateRequest);
        void UpdateClient(int id, ClientUpdateRequest clientUpdateRequest);
        void DeleteClient(int id);
    }
}
