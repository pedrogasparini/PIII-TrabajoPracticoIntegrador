
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ISaleService
    {
        IEnumerable<Sale> GetAllSales();
        Sale GetSaleById(int id);
        void AddSale(Sale sale);
        void UpdateSale(Sale sale);
        void DeleteSale(int id);
    }
}
