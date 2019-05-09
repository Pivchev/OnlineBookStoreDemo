namespace OnlineBookStoreDemo.Services.Models.Books
{
    public class BooksSearchModel
    {
        public int? CategoryId { get; set; }

        public int? SearchLang { get; set; }

        public string PriceRange { get; set; }

        public string SearchSortBy { get; set; }

        public int? CoverFormat { get; set; }

        public bool? InStock { get; set; }

        public int? Page { get; set; } = 1;
    }
}
