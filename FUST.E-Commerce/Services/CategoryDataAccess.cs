using FUST.E_Commerce.Models;
using MySqlConnector;
using Dapper;

namespace FUST.E_Commerce.Services;

public class CategoryDataAccess : ICategoryDataAccess
{
    private string _connectionString;

    public CategoryDataAccess(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("e-commerce") ?? throw new Exception("ConnectionString 'e-commerce' not found.");
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

    public Category? GetCategory(int categoryID)
    {
        using var connection = new MySqlConnection(_connectionString);
        const string query = """
            SELECT 
                categoryID, 
                name
            FROM categories
            WHERE categoryID = @categoryID
            """;
        return connection.QueryFirstOrDefault<Category>(query, new { categoryID });
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

    public void DeleteCategory(Category category)
    {
        using var connection = new MySqlConnection(_connectionString);
        const string query = """
            DELETE FROM categories
            WHERE categoryID = @categoryID
            """;
        connection.Execute(query, category);
    }

    public void UpdateCategory(Category category)
    {
        using var connection = new MySqlConnection(_connectionString);
        const string query = """
            UPDATE categories
            SET name = @name
            WHERE categoryID = @categoryID
            """;
        connection.Execute(query, category);
    }

}