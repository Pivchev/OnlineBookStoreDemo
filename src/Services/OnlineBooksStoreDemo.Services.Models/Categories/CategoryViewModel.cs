namespace OnlineBookStoreDemo.Services.Models.Categories
{
    using System.Collections.Generic;

    public class CategoryViewModel
    {
        public CategoryViewModel()
        {
            this.SubCategories = new List<SubCategoryViewModel>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int? ParentCategoryId { get; set; }

        public string ParentCategoryName { get; set; }

        public IEnumerable<SubCategoryViewModel> SubCategories { get; set; }
    }
}
