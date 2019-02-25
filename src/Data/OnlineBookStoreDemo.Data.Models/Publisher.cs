namespace OnlineBookStoreDemo.Data.Models
{
    using System;
    using System.Collections.Generic;
    using OnlineBookStoreDemo.Data.Common.Models;

    public class Publisher : BaseDeletableModel<int>
    {
        public Publisher()
        {
            this.Books = new HashSet<Book>();
        }

        public int PublisherID { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
