using FUST.E_Commerce.Models;

namespace FUST.E_Commerce.Services
{
    public interface ICategoryDataAccess
    {
        IEnumerable<Category> GetCategories();
        void AddCategory(Category category);
    }
}