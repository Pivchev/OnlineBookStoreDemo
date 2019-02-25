namespace OnlineBookStoreDemo.Data.Models
{
    using OnlineBookStoreDemo.Data.Common.Models;

    public class OrderDetail : BaseDeletableModel<int>
    {
        public int OrderId { get; set; }

        public int Quantity { get; set; }

        public int UnitPrice { get; set; }

        public int BookId { get; set; }

        public virtual Book Book { get; set; }

        public virtual Order Order { get; set; }
    }
}