namespace OnlineBookStoreDemo.Web.Controllers.Catalog
{
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using OnlineBookStoreDemo.Services.Data;

    public class CatalogController : BaseController
    {
        private readonly ICategoriesService categoriesService;

        public CatalogController(
            ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        public IActionResult AllCategories()
        {
            // Main categories "books/" route
            var mainCategories = this.categoriesService.GetAllMainCategories();

            return this.View(mainCategories);
        }

        public IActionResult SubCategories(int? categoryId)
        {
            // Category with sub-categories by given CategoryId
            if (categoryId.HasValue && categoryId > 0)
            {
                var selectedCategory = this.categoriesService.GetNavigationCategoryById(categoryId);

                // TODO: Redirect to Error page instead of /books
                if (selectedCategory == null)
                {
                    return this.Redirect("/books");
                }

                return this.View(selectedCategory);
            }
            else
            {
                // TODO: Redirect to Error page instead of /books
                return this.Redirect("/books");
            }

        }
    }
}
