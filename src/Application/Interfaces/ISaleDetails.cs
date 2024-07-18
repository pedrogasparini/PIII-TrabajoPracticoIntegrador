using Domain.Entities;

namespace Application.Interfaces
{
    public interface ISaleDetailService
    {
        IEnumerable<SaleDetail> GetSaleDetailsBySaleId(int saleId);
        void AddSaleDetail(SaleDetail saleDetail);
        void UpdateSaleDetail(SaleDetail saleDetail);
        void DeleteSaleDetail(int id);
    }
}

