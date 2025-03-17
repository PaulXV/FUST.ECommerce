using FUST.E_Commerce.Models;

namespace FUST.E_Commerce.Services
{
    public interface IUserDataAccess1
    {
        void AddUser(User user);
        int DeleteUser(int userID);
        User? GetUser(int userID);
        IEnumerable<User> GetUsers();
        int UpdateUser(User user);
    }
}