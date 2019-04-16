namespace OnlineBookStoreDemo.Web.Components
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using OnlineBookStoreDemo.Services.Data;

    public class ParentCategoriesNavigationsViewComponent : ViewComponent
    {
        private readonly ICategoriesService categoriesService;

        public ParentCategoriesNavigationsViewComponent(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int categoryId)
        {
            var parentCategories = this.categoriesService.GetAllParentsById(categoryId);
            return this.View(parentCategories);
        }
    }
}
