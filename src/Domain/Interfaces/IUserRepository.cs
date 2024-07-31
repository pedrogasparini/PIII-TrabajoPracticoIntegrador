using Domain.Entities;
using Domain.Interfaces;

namespace Domain;

public interface IUserRepository : IBaseRepository<User>
{
    User? GetUserByUserName(string userName);
}
