namespace FUST.E_Commerce.Services;

using FUST.E_Commerce.Models;
using Dapper;
using MySqlConnector;

public class ProductsDataAccess : IProductsDataAccess
{
    private string _connectionString;

    public ProductsDataAccess(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("e-commerce") ?? throw new Exception("ConnectionString 'e-commerce' not found.");
    }

    public IEnumerable<Product> GetProducts()
    {
        try
        {
            using var connection = new MySqlConnection(_connectionString);
            const string query = """
            SELECT 
                productID, 
                productCode, 
                name,
                quantity,
                price,
                categoryID
            FROM products
            """;
            return connection.Query<Product>(query);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return Enumerable.Empty<Product>();
        }
    }

    public Product? GetProduct(int productID)
    {
        using var connection = new MySqlConnection(_connectionString);
        const string query = """
            SELECT 
                productID, 
                productCode, 
                name,
                quantity,
                price,
                categoryID
            FROM products
            WHERE productID = @productID
            """;
        return connection.QueryFirstOrDefault<Product>(query, new { productID });
    }

    public void AddProduct(Product product)
    {
        using var connection = new MySqlConnection(_connectionString);
        const string query = """
            INSERT INTO products (productCode, name, quantity, price, categoryID)
            VALUES (@productCode, @name, @quantity, @price, @categoryID);
            SELECT last_insert_id();
            """;
        connection.Execute(query, product);
    }

    public int UpdateProduct(Product product)
    {
        using var connection = new MySqlConnection(_connectionString);
        const string query = """
            UPDATE products
            SET productCode = @productCode,
                name = @name,
                quantity = @quantity,
                price = @price,
                categoryID = @categoryID
            WHERE productID = @productID
            """;
        var rowsAffected = connection.Execute(query, product);
        return rowsAffected;
    }

    public int DeleteProduct(int productID)
    {
        using var connection = new MySqlConnection(_connectionString);
        const string query = """
            DELETE FROM products
            WHERE productID = @productID
            """;
        var rowsAffected = connection.Execute(query, new { productID });
        return rowsAffected;
    }

    public IEnumerable<Product> GetProductsByCategory(int categoryId)
    {
        try
        {
            using var connection = new MySqlConnection(_connectionString);
            const string query = """
                SELECT 
                    productID, 
                    productCode, 
                    name,
                    quantity,
                    price,
                    categoryID
                FROM products
                WHERE categoryID = @categoryId
                """;
            return connection.Query<Product>(query, new { categoryId });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return Enumerable.Empty<Product>();
        }
    }

}
