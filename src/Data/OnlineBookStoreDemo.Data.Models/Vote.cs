namespace OnlineBookStoreDemo.Data.Models
{
    using OnlineBookStoreDemo.Data.Common.Models;

    public class Vote : BaseDeletableModel<int>
    {
        public string UserId { get; set; }

        public int BookId { get; set; }

        public virtual Book Book { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}