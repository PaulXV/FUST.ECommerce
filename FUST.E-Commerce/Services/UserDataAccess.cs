

    namespace FUST.E_Commerce.Services;

using FUST.E_Commerce.Models;
using Dapper;
using MySqlConnector;

public class UserDataAccess : IUserDataAccess1
{
    private readonly string _connectionString;

    public UserDataAccess(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("e-commerce") ?? throw new Exception("ConnectionString 'e-commerce' not found.");
    }

    public IEnumerable<User> GetUsers()
    {
        try
        {
            using var connection = new MySqlConnection(_connectionString);
            const string query = """
            SELECT 
                Id, 
                UserName, 
                NormalizedUserName,
                Email,
                NormalizedEmail,
                EmailConfirmed,
                PasswordHash,
                SecurityStamp,
                ConcurrencyStamp,
                PhoneNumber,
                PhoneNumberConfirmed,
                TwoFactorEnabled,
                LockoutEnd,
                LockoutEnabled,
                AccessFailedCount
            FROM aspnetusers
            """;
            return connection.Query<User>(query);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return Enumerable.Empty<User>();
        }
    }

    public User? GetUser(int userID)
    {
        using var connection = new MySqlConnection(_connectionString);
        const string query = """
            SELECT 
                Id, 
                UserName, 
                NormalizedUserName,
                Email,
                NormalizedEmail,
                EmailConfirmed,
                PasswordHash,
                SecurityStamp,
                ConcurrencyStamp,
                PhoneNumber,
                PhoneNumberConfirmed,
                TwoFactorEnabled,
                LockoutEnd,
                LockoutEnabled,
                AccessFailedCount
            FROM aspnetusers
            WHERE Id = @userID
            """;
        return connection.QueryFirstOrDefault<User>(query, new { userID });
    }

    public void AddUser(User user)
    {
        using var connection = new MySqlConnection(_connectionString);
        const string query = """
            INSERT INTO users (UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount)
            VALUES (@UserName, @NormalizedUserName, @Email, @NormalizedEmail, @EmailConfirmed, @PasswordHash, @SecurityStamp, @ConcurrencyStamp, @PhoneNumber, @PhoneNumberConfirmed, @TwoFactorEnabled, @LockoutEnd, @LockoutEnabled, @AccessFailedCount);
            SELECT last_insert_id();
            """;
        connection.Execute(query, user);
    }

    public int UpdateUser(User user)
    {
        using var connection = new MySqlConnection(_connectionString);
        const string query = """
            UPDATE aspnetusers
            SET UserName = @UserName,                    
            PhoneNumber = @PhoneNumber                
            WHERE Id = @Id
            """;
        var rowsAffected = connection.Execute(query, user);
        return rowsAffected;
    }

    public int UpdatePassword(User user)
    {
        using var connection = new MySqlConnection(_connectionString);
        const string query = """
            UPDATE aspnetusers
            SET Password= P@ssw0rd!           
            WHERE Id = @Id
            """;
        var rowsAffected = connection.Execute(query, user);
        return rowsAffected;
    }

    public int DeleteUser(int userID)
    {
        using var connection = new MySqlConnection(_connectionString);
        const string query = """
            DELETE FROM aspnetusers
            WHERE Id = @userID
            """;
        var rowsAffected = connection.Execute(query, new { userID });
        return rowsAffected;
    }
}



