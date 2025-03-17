namespace FUST.E_Commerce.Models;

public class Product
{
    public int ProductID { get; set; }
    public String ProductCode { get; set; } = "";
    public string Name { get; set; } = "";
    public int Quantity { get; set; } = 0;
    public double Price { get; set; } = 99999.99;
    public int CategoryID { get; set; }
}
