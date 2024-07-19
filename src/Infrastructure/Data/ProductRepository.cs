using Domain;
using Domain.Entities;

namespace Infrastructure.Data;

public class ProductRepository : EfRepository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context)
    {
    }
}
