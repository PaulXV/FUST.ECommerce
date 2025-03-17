namespace Brugnola.FUST.TestDotNet.Models;

public class Product
{
    public int productID { get; set; }
    public String productCode { get; set; } = "";
    public string name { get; set; } = "";
    public int quantity { get; set; } = 0;
    public double price { get; set; } = 99999.99;
    required public int categoryID { get; set; }
}
