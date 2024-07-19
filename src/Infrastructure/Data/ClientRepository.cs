using Domain;
using Domain.Entities;

namespace Infrastructure.Data;

public class ClientRepository : EfRepository<Client>, IClientRepository
{
    public ClientRepository(AppDbContext context) : base(context)
    {
    }
}
