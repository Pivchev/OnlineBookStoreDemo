namespace OnlineBookStoreDemo.Services.Models.Books
{
    public class BookSimpleViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool InStock { get; set; }

        public string AuthorName { get; set; }

        public string PictureUrl { get; set; }

        public int Rating { get; set; }

        public decimal Price { get; set; }

        public decimal PriceAfterDiscount { get; set; }

        public decimal Discount { get; set; }

        public int PromotionPercentage { get; set; }
    }
}
