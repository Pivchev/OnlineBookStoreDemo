namespace OnlineBookStoreDemo.Services.Models.Books
{
    using System;

    public class BookDetailsViewModel
    {
        public string Title { get; set; }

        public string AuthorName { get; set; }

        public string PublisherName { get; set; }

        public string Category { get; set; }

        public string ISBN { get; set; }

        public string Language { get; set; }

        public string TranslatorName { get; set; }

        public int Weight { get; set; }

        public string BackCover { get; set; }

        public decimal Price { get; set; }

        public string Size { get; set; }

        public bool InStock { get; set; }

        public string Description { get; set; }

        public DateTime Year { get; set; }

        public int PageCount { get; set; }

        public string PictureUrl { get; set; }
    }
}
