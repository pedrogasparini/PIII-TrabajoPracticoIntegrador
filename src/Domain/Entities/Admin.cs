
namespace Domain.Entities
{
    public class Admin : User 
    {
        public Admin() { }
        public Admin(string name, string lastname, string email, string username, string password)
        {
            Name = name;
            LastName = lastname;
            Email = email;
            Username = username;
            Password = password;
        }
    }
}
