
using Domain.Entities;

namespace Application.Models
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int StockAvailable { get; set; }

        public static ProductDTO Create(Product product)
        {
            return new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                StockAvailable = product.StockAvailable
            };
        }
    }
}