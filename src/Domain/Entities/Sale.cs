
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Xml.Linq;

namespace Domain.Entities
{
    public class Sale
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        [Required]
        public ICollection<SaleDetail>? SaleDetails { get; set; }

        public decimal Total { get; set; }

        public Sale() { }
        public Sale(DateTime date, ICollection<SaleDetail> saleDetail , decimal total)
        {
            Date=date;
            SaleDetails= saleDetail;
            Total = total;
        }
    }
}
