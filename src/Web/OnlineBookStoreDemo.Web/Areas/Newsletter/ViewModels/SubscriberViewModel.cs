namespace OnlineBookStoreDemo.Web.Areas.Newsletter.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class SubscriberViewModel
    {
        [Required (ErrorMessage = "Enter something!")]
        [EmailAddress(ErrorMessage = "ERROR ERROR!")]
        public string Email { get; set; }
    }
}