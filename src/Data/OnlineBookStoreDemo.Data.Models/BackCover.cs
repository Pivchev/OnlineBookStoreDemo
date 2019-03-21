using OnlineBookStoreDemo.Data.Common.Models;
using System.ComponentModel.DataAnnotations;

namespace OnlineBookStoreDemo.Data.Models
{
    public class BackCover : BaseDeletableModel<int>
    {
        [Required]
        public string Name { get; set; }
    }
}