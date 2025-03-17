namespace Brugnola.FUST.TestDotNet.Services;

using Brugnola.FUST.TestDotNet.Models;

public interface IProductsDataAccess
{
    IEnumerable<Product> GetProducts();
    Product? GetProduct(int productID);
    void AddProduct(Product product);
    int UpdateProduct( Product product);
    int DeleteProduct(int productID);

}