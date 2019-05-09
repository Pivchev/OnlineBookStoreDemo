namespace OnlineBookStoreDemo.Web.Controllers
{
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using OnlineBookStoreDemo.Data.Common.Repositories;
    using OnlineBookStoreDemo.Data.Models;
    using OnlineBookStoreDemo.Services.Models.Categories;

    public class BookController : BaseController
    {
        private readonly IDeletableEntityRepository<Book> books;
        private readonly IDeletableEntityRepository<Category> categories;

        public BookController(
            IDeletableEntityRepository<Book> books,
            IDeletableEntityRepository<Category> categories)
        {
            this.books = books;
            this.categories = categories;
        }

        public ContentResult Details()
        {
            return Content("");
        }

        public IActionResult List()
        {
            var baseCategories = this.categories.All()
                .Where(x => !(x.ParentCategoryId.HasValue))
                .Select(x => new CategoryViewModel
                {
                    Name = x.Name,
                })
                .ToList();

            //var listOfIds = db.OrderDetail.Where(n => n.OrderId == id).Select(x => x.item_id);
            //var itemEntity = db.ItemsEntity.Where(m => listOfIds.Contains(m.item_id));

            return this.View(baseCategories);
        }
    }
}