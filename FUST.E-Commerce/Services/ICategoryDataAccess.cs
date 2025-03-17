using FUST.E_Commerce.Models;

namespace FUST.E_Commerce.Services
{
    public interface ICategoryDataAccess
    {
        IEnumerable<Category> GetCategories();
        Category? GetCategory(int categoryID);
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);
    }
}