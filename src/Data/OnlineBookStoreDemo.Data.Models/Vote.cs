using OnlineBookStoreDemo.Data.Common.Models;

namespace OnlineBookStoreDemo.Data.Models
{
    public class Vote : BaseDeletableModel<int>
    {
        public int UserId { get; set; }
        public int BookId { get; set; }

        public virtual Book Book { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}