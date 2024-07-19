
namespace Domain.Entities
{
    public class Client : User
    {
        public Client() { }
        public Client(string name, string lastname, string email, string username, string password)
        {
            Name = name;
            LastName = lastname;
            Email = email;
            Username = username;
            Password = password;
        }

    }
}