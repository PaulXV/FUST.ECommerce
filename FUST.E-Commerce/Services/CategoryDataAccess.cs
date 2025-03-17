using FUST.E_Commerce.Models;
using MySqlConnector;
using Dapper;

namespace FUST.E_Commerce.Services;

public class CategoryDataAccess : ICategoryDataAccess
{
    private string _connectionString;

    public CategoryDataAccess(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("testdotnet") ?? throw new Exception("ConnectionString 'testdotnet' not found.");
    }

    public IEnumerable<Category> GetCategories()
    {
        try
        {
            using var connection = new MySqlConnection(_connectionString);
            const string query = """
                SELECT 
                    categoryID, 
                    name
                FROM categories
                """;
            return connection.Query<Category>(query);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return Enumerable.Empty<Category>();
        }
    }

    public void AddCategory(Category category)
    {
        using var connection = new MySqlConnection(_connectionString);
        const string query = """
            INSERT INTO categories (name)
            VALUES (@name)
            """;
        connection.Execute(query, category);
    }

}