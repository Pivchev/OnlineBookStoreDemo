namespace OnlineBookStoreDemo.Web.Components
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using OnlineBookStoreDemo.Data.Common.Repositories;
    using OnlineBookStoreDemo.Data.Models;

    public class BestSellersViewComponent : ViewComponent
    {
        private readonly IDeletableEntityRepository<Book> books;

        public BestSellersViewComponent(IDeletableEntityRepository<Book> books)
        {
            this.books = books;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // TODO: Remove Randomizer

            // Need to be 8+ items for the template
            var bestSellersList = this.books.All().OrderBy(r => Guid.NewGuid()).Take(8).ToList();
            return this.View(bestSellersList);
        }
    }
}
