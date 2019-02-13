namespace OnlineBookStoreDemo.Web.ViewModels.Settings
{
    using OnlineBookStoreDemo.Data.Models;
    using OnlineBookStoreDemo.Services.Mapping;

    public class SettingViewModel : IMapFrom<Setting>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }
    }
}
