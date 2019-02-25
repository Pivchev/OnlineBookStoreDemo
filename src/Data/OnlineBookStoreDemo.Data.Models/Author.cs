namespace OnlineBookStoreDemo.Data.Models
{
    using System.Collections.Generic;

    using OnlineBookStoreDemo.Data.Common.Models;

    public class Author : BaseDeletableModel<int>
    {
        public Author()
        {
            this.Books = new HashSet<Book>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
