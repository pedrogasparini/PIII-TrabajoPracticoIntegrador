﻿namespace Domain;

public class SaleDetail
{
    public int SaleDetailId { get; set; }
    public int SaleId { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Subtotal => Quantity * UnitPrice;
}
