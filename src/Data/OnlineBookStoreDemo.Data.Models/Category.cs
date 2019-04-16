namespace OnlineBookStoreDemo.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using OnlineBookStoreDemo.Data.Common.Models;

    public class Category : BaseDeletableModel<int>
    {
        public Category()
        {
            this.Books = new HashSet<Book>();
            this.SubCategories = new List<Category>();
        }

        [Required]
        public string Name { get; set; }

        public int? ParentCategoryId { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        [ForeignKey("ParentCategoryId")]
        public virtual Category ParentCategory { get; set; }

        public virtual ICollection<Category> SubCategories { get; set; }
    }
}