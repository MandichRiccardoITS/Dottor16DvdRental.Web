using Dottor16DvdRental.Web.models;

namespace Dottor16DvdRental.Web.services.CategoriesServices;

public interface ICategoriesServices
{
    Task<IEnumerable<Category>> GetCategoriesAsync();
    Task<Category> GetCategoryByIdAsync(int id);
    Task<int> InsertCategoryAsync(Category category);
    Task UpdateCategoryAsync(Category category);
    Task DeleteCategoryAsync(int id);
}
