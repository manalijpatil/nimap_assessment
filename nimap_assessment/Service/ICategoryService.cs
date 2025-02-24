using nimap_assessment.Models;

namespace nimap_assessment.Service
{
    public interface ICategoryService
    {
        List<Category> GetAllCaterories();
        Category GetCategoryById(int id);
        int AddCategory(Category category);
        int UpdateCategory(Category category);
        int DeleteCategory(int id);

    }
}
