namespace OnlineBookStoreDemo.Web.Controllers.Catalog
{
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using OnlineBookStoreDemo.Services.Data;
    using OnlineBookStoreDemo.Services.Models.Books;
    using X.PagedList;

    public class CatalogController : BaseController
    {
        private readonly ICategoriesService categoriesService;
        private readonly IBooksService booksService;

        public CatalogController(
            ICategoriesService categoriesService,
            IBooksService booksService)
        {
            this.categoriesService = categoriesService;
        }

        public IActionResult AllCategories()
        {
            // Main categories "books/" route
            var mainCategories = this.categoriesService.GetAllMainCategories();

            return this.View(mainCategories);
        }

        public IActionResult SubCategories(BooksSearchModel booksSearchModel)
        {
            // Category with sub-categories by given CategoryId
            if (booksSearchModel.CategoryId.HasValue && booksSearchModel.CategoryId > 0)
            {
                var selectedCategory = this.categoriesService.GetNavigationCategoryById(booksSearchModel.CategoryId);

                // TODO: Redirect to Error page instead of /books
                if (selectedCategory == null)
                {
                    return this.Redirect("/books");
                }

                // Getting books by SearchModel
                var books = this.booksService.GetBooksBySearchModel(booksSearchModel);

                // Paging the books list result
                var pageNumber = booksSearchModel.Page ?? 1;
                int pageSize = 25;
                var onePageOfBooks = books.ToPagedList(pageNumber, pageSize); // will only contain 25 products max because of the pageSize

                this.ViewBag.OnePageOfBooks = onePageOfBooks;

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
