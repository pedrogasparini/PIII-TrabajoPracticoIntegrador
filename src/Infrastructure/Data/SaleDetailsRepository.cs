using Domain;
using Domain.Entities;

namespace Infrastructure.Data;

public class SaleDetailsRepository : EfRepository<SaleDetail>, ISaleDetailsRepository
{
    public SaleDetailsRepository(AppDbContext context) : base(context)
    {
    }
}
