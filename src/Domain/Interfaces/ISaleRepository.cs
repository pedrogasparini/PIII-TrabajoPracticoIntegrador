
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ISaleRepository
    {
        IEnumerable<Sale> GetAllSales();
        Sale GetSaleById(int id);
        void AddSale(Sale sale);
        void UpdateSale(Sale sale);
        void DeleteSale(Sale sale);
    }
}

