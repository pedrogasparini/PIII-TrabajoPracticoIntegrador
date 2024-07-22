
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Xml.Linq;

namespace Domain.Entities
{
    public class SaleDetail
    {
        public int Id { get; set; }
        public int SaleId { get; set; }

        [Required]
        public Sale Sale { get; set; }
        public int ProductId { get; set; }

        [Required]
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        
        public SaleDetail() { }
        public SaleDetail(Sale sale, Product product, int quantity, decimal unitPrice)
        {
            Sale = sale;
            Product = product;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }
    }
}