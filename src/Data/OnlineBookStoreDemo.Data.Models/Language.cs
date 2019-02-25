namespace OnlineBookStoreDemo.Data.Models
{
    using System.Collections.Generic;

    using OnlineBookStoreDemo.Data.Common.Models;

    public class Language : BaseDeletableModel<int>
    {
        public Language()
        {
            this.Books = new HashSet<Book>();
        }

        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}