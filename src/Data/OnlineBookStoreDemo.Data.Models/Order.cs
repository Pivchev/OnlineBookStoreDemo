﻿namespace OnlineBookStoreDemo.Data.Models
{
    using System;
    using System.Collections.Generic;

    using OnlineBookStoreDemo.Data.Common.Models;

    public class Order : BaseDeletableModel<int>
    {
        public Order()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
        }

        public DateTime OrderDate { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public decimal Total { get; set; }


        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}