namespace OnlineBookStoreDemo.Web.Components
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using OnlineBookStoreDemo.Services.Data;
    using OnlineBookStoreDemo.Services.Models.Books;

    public class BooksGridViewComponent : ViewComponent
    {
        private readonly IBooksService booksService;

        public BooksGridViewComponent(IBooksService booksService)
        {
            this.booksService = booksService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int categoryId)
        {
            var booksGridModel = new List<BookSimpleViewModel>();

            if (categoryId > 0)
            {
                booksGridModel = this.booksService.GetBooksByCategoryId(categoryId).Take(12).ToList();
            }
            else
            {
                booksGridModel = this.booksService.GetAllBooks().Take(12).ToList();
            }

            return this.View(booksGridModel);
        }
    }
}
