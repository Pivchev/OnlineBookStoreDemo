namespace OnlineBookStoreDemo.Data.Models
{
    using OnlineBookStoreDemo.Data.Common.Models;

    public class Comment : BaseDeletableModel<int>
    {
        public int BookId { get; set; }

        public int UserId { get; set; }

        public string Content { get; set; }

        public virtual Book Book { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}