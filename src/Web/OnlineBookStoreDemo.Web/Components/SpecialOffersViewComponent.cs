namespace OnlineBookStoreDemo.Web.Components
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using OnlineBookStoreDemo.Data.Common.Repositories;
    using OnlineBookStoreDemo.Data.Models;
    using OnlineBookStoreDemo.Services.Models.Home;

    public class SpecialOffersViewComponent : ViewComponent
    {
        private readonly IDeletableEntityRepository<Book> books;

        public SpecialOffersViewComponent(IDeletableEntityRepository<Book> books)
        {
            this.books = books;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // TODO: Remove randomize data

            var promoBooks = new List<SpecialOfferViewModel>();
            var allBooks = this.books.All();

            // Special Offers
            SpecialOfferViewModel onSale = new SpecialOfferViewModel();
            onSale.Name = "On Sale";
            onSale.Id = "on-sale";
            onSale.Books = allBooks.OrderBy(r => Guid.NewGuid()).Take(10).ToList();
            promoBooks.Add(onSale);

            // Featured Books
            SpecialOfferViewModel featuredBooks = new SpecialOfferViewModel();
            featuredBooks.Name = "Featured Books";
            featuredBooks.Id = "featured-books";
            featuredBooks.Books = allBooks.OrderBy(r => Guid.NewGuid()).Take(10).ToList();
            promoBooks.Add(featuredBooks);

            // Coming Soon
            SpecialOfferViewModel comingSoon = new SpecialOfferViewModel();
            comingSoon.Name = "Coming Soon";
            comingSoon.Id = "coming-soon";
            comingSoon.Books = allBooks.OrderBy(r => Guid.NewGuid()).Take(10).ToList();
            promoBooks.Add(comingSoon);

            return this.View(promoBooks);
        }
    }
}
