
using Domain.Entities;

namespace Application.Models
{
    public class SaleDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public ICollection<SaleDetailDTO> SaleDetails { get; set; }

        public static SaleDTO Create(Sale sale)
        {
            return new SaleDTO
            {
                Id = sale.Id,
                Date = sale.Date,
                Total = sale.Total,
                SaleDetails = sale.SaleDetails != null ? SaleDetailDTO.CreateList(sale.SaleDetails) : null
            };
        }

        public static List<SaleDTO> CreateList(IEnumerable<Sale> sales)
        {
            List<SaleDTO> listDto = new List<SaleDTO>();
            foreach (var sale in sales)
            {
                listDto.Add(Create(sale));
            }
            return listDto;
        }
    }
}
