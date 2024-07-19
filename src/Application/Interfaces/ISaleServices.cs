
using Application.Models.Request;
using Application.Models;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ISaleService
    {
        IEnumerable<SaleDTO> GetAllSales();
        SaleDTO GetSaleById(int id);
        void CreateSale(SaleCreateRequest saleCreateRequest);
        void UpdateSale(int id, SaleUpdateRequest saleUpdateRequest);
        void DeleteSale(int id);
    }
}
