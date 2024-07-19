
using Domain.Entities;

namespace Application.Models
{
    public class SaleDetailDTO
    {
        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public static SaleDetailDTO Create(SaleDetail saleDetail)
        {
            return new SaleDetailDTO
            {
                SaleId = saleDetail.SaleId,
                ProductId = saleDetail.ProductId,
                Quantity = saleDetail.Quantity,
                UnitPrice = saleDetail.UnitPrice
            };
        }

        public static List<SaleDetailDTO> CreateList(IEnumerable<SaleDetail> saleDetails)
        {
            List<SaleDetailDTO> listDto = new List<SaleDetailDTO>();
            foreach (var sd in saleDetails)
            {
                listDto.Add(Create(sd));
            }
            return listDto;
        }
    }
}
