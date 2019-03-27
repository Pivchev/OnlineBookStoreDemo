using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineBookStoreDemo.Data.Models;

namespace OnlineBookStoreDemo.Web.ViewModels
{
    public class SpecialOfferViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}
