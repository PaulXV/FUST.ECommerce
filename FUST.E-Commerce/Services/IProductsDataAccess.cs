namespace FUST.E_Commerce.Services;

using FUST.E_Commerce.Models;

public interface IProductsDataAccess
{
    IEnumerable<Product> GetProducts();
    Product? GetProduct(int productID);
    void AddProduct(Product product);
    int UpdateProduct( Product product);
    int DeleteProduct(int productID);

}