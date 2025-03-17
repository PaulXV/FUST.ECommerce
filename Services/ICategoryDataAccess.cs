using Brugnola.FUST.TestDotNet.Models;

namespace Brugnola.FUST.TestDotNet.Services
{
    public interface ICategoryDataAccess
    {
        IEnumerable<Category> GetCategories();
        void AddCategory(Category category);
        IEnumerable<Product> GetProductsByCategory(int categoryId);
    }
}