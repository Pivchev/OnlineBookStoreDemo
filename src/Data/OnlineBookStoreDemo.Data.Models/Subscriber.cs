using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using OnlineBookStoreDemo.Data.Common.Models;

namespace OnlineBookStoreDemo.Data.Models
{
    public class Subscriber : BaseDeletableModel<int>
    {
        public string Email { get; set; }
    }
}
