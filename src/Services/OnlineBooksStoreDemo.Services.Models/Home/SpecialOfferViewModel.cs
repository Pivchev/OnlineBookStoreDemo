namespace OnlineBookStoreDemo.Services.Models.Home
{
    using OnlineBookStoreDemo.Data.Models;
    using System.Collections.Generic;

    public class SpecialOfferViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}
