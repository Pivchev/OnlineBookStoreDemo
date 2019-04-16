using System.Collections.Generic;
using System.Linq;
using AngleSharp.Dom;

namespace Sandbox
{
    using System;
    using System.Diagnostics;
    using System.IO;

    using OnlineBookStoreDemo.Data;
    using OnlineBookStoreDemo.Data.Common;
    using OnlineBookStoreDemo.Data.Common.Repositories;
    using OnlineBookStoreDemo.Data.Models;
    using OnlineBookStoreDemo.Data.Repositories;
    using OnlineBookStoreDemo.Data.Seeding;
    using OnlineBookStoreDemo.Services.Data;
    using OnlineBookStoreDemo.Services.Messaging;

    using CommandLine;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.UI.Services;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using System.Threading;
    using System.Text;
    using System.Net;
    using AngleSharp.Html.Parser;
    using OnlineBookStoreDemo.Web.Infrastructure;
    using System.Text.RegularExpressions;
    using OnlineBookStoreDemo.Services;

    public static class Program
    {
        public static int Main(string[] args)
        {
            Console.WriteLine($"{typeof(Program).Namespace} ({string.Join(" ", args)}) starts working...");
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider(true);

            // Seed data on application startup
            using (var serviceScope = serviceProvider.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<BookStoreDbContext>();
                dbContext.Database.Migrate();
                new BookStoreDbContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
            }

            using (var serviceScope = serviceProvider.CreateScope())
            {
                serviceProvider = serviceScope.ServiceProvider;

                return Parser.Default.ParseArguments<SandboxOptions>(args).MapResult(
                    opts => SandboxCode(opts, serviceProvider),
                    _ => 255);
            }
        }

        private static int SandboxCode(SandboxOptions options, IServiceProvider serviceProvider)
        {
            var dbContext = serviceProvider.GetService<BookStoreDbContext>();
            var categoryService = serviceProvider.GetService<ICategoriesService>();

            //var categories = dbContext.Categories
            //    .Include(x => x.SubCategories)
            //    .AsEnumerable()
            //    .Where(x => x.ParentCategory == null)
            //    .ToList();

            //foreach (var suBcategory in categories)
            //{
            //    TraverseTreeDFS.TraverseTree(suBcategory, string.Empty);
            //}

            var allParents = categoryService.GetAllParentsById(12);

            foreach (var item in allParents)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("--------END----------");

            return 0;
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .AddEnvironmentVariables()
                .Build();

            services.AddSingleton<IConfiguration>(configuration);
            services.AddDbContext<BookStoreDbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                    .UseLoggerFactory(new LoggerFactory()));

            services
                .AddIdentity<ApplicationUser, ApplicationRole>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequiredLength = 6;
                })
                .AddEntityFrameworkStores<BookStoreDbContext>()
                .AddUserStore<ApplicationUserStore>()
                .AddRoleStore<ApplicationRoleStore>()
                .AddDefaultTokenProviders();

            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IDbQueryRunner, DbQueryRunner>();

            // Application services
            services.AddTransient<IEmailSender, NullMessageSender>();
            services.AddTransient<ISmsSender, NullMessageSender>();
            services.AddTransient<ISettingsService, SettingsService>();
            services.AddTransient<IServiceProvider, ServiceProvider>();
            services.AddTransient<ICategoriesService, CategoriesService>();
        }
    }
}
