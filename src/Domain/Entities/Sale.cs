
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Sale
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        [Required]
        public ICollection<SaleDetail>? SaleDetails { get; set; }

        public decimal Total { get; set; }
    }
}
