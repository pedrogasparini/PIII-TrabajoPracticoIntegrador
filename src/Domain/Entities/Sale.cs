
public class Sale
{
    public int SaleId { get; set; }
    public int ClientId { get; set; }
    public Client Client { get; set; }
    public List<SaleDetail> SaleDetails { get; set; }
    public DateTime SaleDate { get; set; }
}
