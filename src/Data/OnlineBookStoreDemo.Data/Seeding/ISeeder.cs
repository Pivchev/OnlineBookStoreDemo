namespace OnlineBookStoreDemo.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    public interface ISeeder
    {
        Task SeedAsync(BookStoreDbContext dbContext, IServiceProvider serviceProvider);
    }
}
