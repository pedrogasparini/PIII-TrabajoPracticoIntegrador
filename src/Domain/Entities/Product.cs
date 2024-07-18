
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
  public class Product
  {
    public int Id { get; set; }

    [Required]
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public int StockAvailable { get; set; }
  }
}

