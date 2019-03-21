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
            Console.OutputEncoding = Encoding.UTF8;
            var dbContext = serviceProvider.GetService<BookStoreDbContext>();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var parser = new HtmlParser();
            //var webClient = new WebClient { Encoding = Encoding.GetEncoding("utf-8") };

            //Create htmlDocs and webClients
            var url = "http://www.bookpoint.bg/";
            List<string> htmlDocs = new List<string>(100);
            List<WebClient> webClients = new List<WebClient>(100);
            string urlParams = "";

            for (int level = 0; level < 10; level++)
            {
                htmlDocs.Add(new string(""));
                webClients.Add(new WebClient());

                htmlDocs[level] = webClients[level].DownloadString(url + urlParams);
                var document = parser.ParseDocument(htmlDocs[level]);
                var documentLinks = document.Links;

                foreach (var hyperLink in documentLinks)
                {
                    if (hyperLink.ClassName != null && hyperLink.ClassName.Contains("level" + level))
                    {
                        // Console Write level 1
                        Console.WriteLine("level" + level + " - " + hyperLink.TextContent);
                    }

                    urlParams = hyperLink.Attributes[0].Value;
                }
                
            }

            return 0;
        }

        //void PrintCategories(string htmlDoc, WebClient webClient, string urlParams, string url)
        //{
        //    HtmlParser parser = new HtmlParser();
        //    for (int level = 0; level < 10; level++)
        //    {
        //        htmlDoc = webClient.DownloadString(url + urlParams);
        //        var document = parser.ParseDocument(htmlDocs[level]);
        //        var documentLinks = document.Links;

        //        foreach (var hyperLink in documentLinks)
        //        {
        //            if (hyperLink.ClassName != null && hyperLink.ClassName.Contains("level" + level))
        //            {
        //                // Console Write level 1
        //                Console.WriteLine("level" + level + " - " + hyperLink.TextContent);
        //            }

        //            urlParams = hyperLink.Attributes[0].Value;
        //        }

        //    }
        //}



        //for (var i = 1; i < 210; i++)
        //{
        //    var url = "http://www.bookpoint.bg/?cid=3&cat=" + i;
        //    string html = null;
        //    for (int j = 0; j < 10; j++)
        //    {
        //        try
        //        {
        //            html = webClient.DownloadString(url);
        //            break;
        //        }
        //        catch (Exception)
        //        {
        //            Thread.Sleep(10000);
        //        }
        //    }

        //    if (string.IsNullOrWhiteSpace(html))
        //    {
        //        continue;
        //    }

        //    var document = parser.ParseDocument(html);

        //var categoryName = document.QuerySelector("h1")?.TextContent?.Trim(); // Get all categories

        //if (!string.IsNullOrWhiteSpace(categoryName))
        //{
        //    var category = new Category
        //    {
        //        Name = categoryName,
        //    };

        //    dbContext.Categories.Add(category);
        //    dbContext.SaveChanges();
        //}


        //Console.WriteLine($"{i} => {categoryName}");
        //}

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
        }
    }
}
