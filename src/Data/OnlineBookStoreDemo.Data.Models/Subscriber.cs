using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using OnlineBookStoreDemo.Data.Common.Models;

namespace OnlineBookStoreDemo.Data.Models
{
    public class Subscriber : BaseDeletableModel<int>
    {
        [Required(ErrorMessage = "Please enter your email address here.")]
        [EmailAddress(ErrorMessage = "Please enter valid email address.")]
        public string Email { get; set; }
    }
}
