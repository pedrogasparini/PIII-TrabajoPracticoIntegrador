
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
  public class Product
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int StockAvailable { get; set; }

        public Product() { }
        public Product(string name, decimal price, int stockAvailable)
        {
            Name = name;
            Price = price;
            StockAvailable = stockAvailable;
        }
    }
}

