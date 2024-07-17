
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public float Price { get; set; }
    public int StockAvailable { get; set; }
    public List<string> StockList { get; set; } // Lista de información detallada del stock

    public Product()
    {
        StockList = new List<string>();
    }
}


