namespace OnlineBookStoreDemo.Services.Models.Catalog
{
    using System.Collections.Generic;

    public class NavigationCategoryViewModel
    {
        public NavigationCategoryViewModel()
        {
            this.SubCategoriesList = new List<CategoryIdAndNameViewModel>();
            this.ParentsList = new List<CategoryIdAndNameViewModel>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public List<CategoryIdAndNameViewModel> SubCategoriesList { get; set; }

        public List<CategoryIdAndNameViewModel> ParentsList { get; set; }
    }
}
