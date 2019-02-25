namespace OnlineBookStoreDemo.Data.Models
{
    using System.Collections.Generic;

    using OnlineBookStoreDemo.Data.Common.Models;

    public class Category : BaseDeletableModel<int>
    {
        public Category()
        {
            this.Books = new HashSet<Book>();
            this.Childrens = new List<Category>();
        }

        public string Name { get; set; }

        public int? ParentId { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        public virtual Category Parent { get; set; }

        public virtual ICollection<Category> Childrens { get; set; }
    }
}