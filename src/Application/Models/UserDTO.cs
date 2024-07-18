
using Domain.Entities;

namespace Application.Models
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public static UserDTO Create(User user)
        {
            return new UserDTO
            {
                Id = user.Id,
                Username = user.Username,
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email,
            };
        }
    }
}
