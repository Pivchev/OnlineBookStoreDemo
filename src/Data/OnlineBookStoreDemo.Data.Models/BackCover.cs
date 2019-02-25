using OnlineBookStoreDemo.Data.Common.Models;

namespace OnlineBookStoreDemo.Data.Models
{
    public class BackCover : BaseDeletableModel<int>
    {
        public string Name { get; set; }
    }
}