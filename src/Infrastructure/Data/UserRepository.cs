using Domain;
using Domain.Entities;

namespace Infrastructure.Data;

public class UserRepository : EfRepository<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }
}