using Application.Models.Request;
using Application.Models;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ISaleDetailService
    {
        IEnumerable<SaleDetailDTO> GetAllSaleDetails();
        SaleDetailDTO GetSaleDetailById(int id);
        void CreateSaleDetail(SaleDetailCreateRequest saledetailCreateRequest);
        void UpdateSaleDetail(int id, SaleDetailUpdateRequest saledetailUpdateRequest);
        void DeleteSaleDetail(int id);
    }
}


