namespace OnlineBookStoreDemo.Web.Areas.Newsletter.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using OnlineBookStoreDemo.Web.Areas.Newsletter.ViewModels;

    public class SubscriberController : Controller
    {
        // POST: Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(SubscriberViewModel subscriber)
        {
            if (this.ModelState.IsValid)
            {
                return this.Json("OK!");
            }
            else
            {
                return this.Json("ERROR!");
            }
        }
    }
}