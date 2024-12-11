

using ShopApp.DAL.Models.Category;

namespace ShopApp.DAL.Interfaces
{
    public interface IDaoCategory
    {
        void CreateCategory(CategoryCreateOrUpdateModel categoryCreateOrUpdateModel);

        void ModifyCategory(CategoryCreateOrUpdateModel categoryCreateOrUpdateModel);

        void RemoveCategory(CategoryRemoveModel categoryRemoveModel);

        GetCategoryModel GetCategoryById(int categoryId);

        List<GetCategoryModel> GetCategories();
    }
}
