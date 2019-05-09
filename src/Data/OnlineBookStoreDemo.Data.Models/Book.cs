using System.ComponentModel.DataAnnotations;

namespace OnlineBookStoreDemo.Data.Models
{
    using System;
    using System.Collections.Generic;
    using OnlineBookStoreDemo.Data.Common.Models;

    public class Book : BaseDeletableModel<int>
    {
        public Book()
        {
            this.Comments = new HashSet<Comment>();
            this.OrderDetails = new HashSet<OrderDetail>();
            this.Votes = new HashSet<Vote>();
        }

        [Required]
        public string Title { get; set; }

        public int AuthorId { get; set; }

        public int PublisherId { get; set; }

        public int CategoryId { get; set; }

        [Required]
        public string ISBN { get; set; }

        public int LanguageId { get; set; }

        public string TranslatorName { get; set; }

        public int Weight { get; set; }

        public int BackCoverId { get; set; }

        public decimal Price { get; set; }

        public string Size { get; set; }

        [Range(0, 90, ErrorMessage = "The promotion precentige must be between 0% and 90%")]
        public int PromotionPercentage { get; set; }

        public bool InStock { get; set; }

        public string Description { get; set; }

        public DateTime Year { get; set; }

        public int PageCount { get; set; }

        public string PictureUrl { get; set; }

        public virtual Author Author { get; set; }

        public virtual Category Category { get; set; }

        public virtual Language Language { get; set; }

        public virtual Publisher Publisher { get; set; }

        public virtual BackCover BackCover { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }
    }
}
