using Microsoft.AspNetCore.Mvc;

namespace OnlineBookStoreDemo.Web.Controllers
{
    public class Shop : BaseController
    {
        // GET
        public IActionResult SingleBookDetails()
        {
            return View();
        }
    }
}