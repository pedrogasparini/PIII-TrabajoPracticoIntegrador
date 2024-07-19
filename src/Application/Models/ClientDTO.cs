
using Domain.Entities;

namespace Application.Models
{
    public class ClientDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public static ClientDTO Create(Client client)
        {
            return new ClientDTO
            {
                Id = client.Id,
                Username = client.Username,
                Name = client.Name,
                LastName = client.LastName,
                Email = client.Email,
            };
        }

        public static List<ClientDTO> CreateList(IEnumerable<Client> clients)
        {
            List<ClientDTO> listDto = new List<ClientDTO>();
            foreach (var client in clients)
            {
                listDto.Add(Create(client));
            }
            return listDto;
        }
    }
}
