namespace OnlineBookStoreDemo.Web.Components
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using OnlineBookStoreDemo.Data.Common.Repositories;
    using OnlineBookStoreDemo.Data.Models;

    public class NewReleasesViewComponent : ViewComponent
    {
        private readonly IDeletableEntityRepository<Book> books;

        public NewReleasesViewComponent(IDeletableEntityRepository<Book> books)
        {
            this.books = books;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var allBooks = this.books.All();
            var lastFiveAddedBooks = allBooks.Skip(Math.Max(0, allBooks.Count() - 5));
            return this.View(lastFiveAddedBooks);
        }
    }
}
