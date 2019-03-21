using OnlineBookStoreDemo.Data.Common.Repositories;
using OnlineBookStoreDemo.Data.Models;

namespace OnlineBookStoreDemo.Web.Areas.Newsletter.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class SubscriberController : Controller
    {
        public readonly IDeletableEntityRepository<Subscriber> subscribers;

        public SubscriberController(IDeletableEntityRepository<Subscriber> subscribers)
        {
            this.subscribers = subscribers;
        }

        // POST: Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Subscriber subscriber)
        {
            if (this.ModelState.IsValid)
            {
                this.subscribers.AddAsync(subscriber);
                this.subscribers.SaveChangesAsync();
                return this.Json("OK!");
            }
            else
            {
                return this.Json("ERROR!");
            }
        }
    }
}