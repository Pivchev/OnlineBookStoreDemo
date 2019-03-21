using System.Linq;
using OnlineBookStoreDemo.Data.Common.Repositories;

namespace OnlineBookStoreDemo.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using OnlineBookStoreDemo.Data.Models;

    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => this.View();
    }
}
