namespace OnlineBookStoreDemo.Services.Models.Categories
{
    public class SubCategoryViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ParentName { get; set; }

        public int? ParentId { get; set; }
    }
}
