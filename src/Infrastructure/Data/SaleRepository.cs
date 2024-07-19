using Domain;
using Domain.Entities;

namespace Infrastructure.Data;

public class SaleRepository : EfRepository<Sale>, ISaleRepository
{
    public SaleRepository(AppDbContext context) : base(context)
    {
    }
}
