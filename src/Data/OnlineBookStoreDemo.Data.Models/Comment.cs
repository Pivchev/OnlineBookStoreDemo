namespace OnlineBookStoreDemo.Data.Models
{
    using OnlineBookStoreDemo.Data.Common.Models;
    using System.ComponentModel.DataAnnotations;

    public class Comment : BaseDeletableModel<int>
    {
        public int BookId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string Content { get; set; }

        public virtual Book Book { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}