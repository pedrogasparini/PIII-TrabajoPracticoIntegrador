using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class SaleRepository : EfRepository<Sale>, ISaleRepository
{
    public SaleRepository(AppDbContext context) : base(context)
    {
    }
    public List<Sale> GetAll()
    {
        return _context.Set<Sale>().Include(s => s.SaleDetails).ToList();
    }
    public Sale? GetById<TId>(TId id)
    {
        return _context.Set<Sale>().Include(s => s.SaleDetails).FirstOrDefault(e => e.Id.Equals(id));
    }
}
