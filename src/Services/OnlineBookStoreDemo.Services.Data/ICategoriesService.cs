namespace OnlineBookStoreDemo.Services.Data
{
    using System.Collections.Generic;

    using OnlineBookStoreDemo.Services.Models.Categories;

    public interface ICategoriesService
    {
        IEnumerable<CategoryViewModel> GetAll();

        CategoryViewModel GetCategoryById(int? categoryId);

        IEnumerable<CategoryViewModel> GetAllSubCategoriesByParentId(int? parentCategoryId);

        IEnumerable<CategoryViewModel> GetAllMainCategories();

        CategoryViewModel GetCategoryRootById(int? categoryId);

        List<CategoryIdAndNameViewModel> GetAllParentsById(int? categoryId);

        NavigationCategoryViewModel GetNavigationCategoryById(int? categoryId);
    }
}
