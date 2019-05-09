namespace OnlineBookStoreDemo.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using OnlineBookStoreDemo.Data.Common.Repositories;
    using OnlineBookStoreDemo.Data.Models;
    using OnlineBookStoreDemo.Services.Models.Books;

    public class BooksService : IBooksService
    {
        private readonly IDeletableEntityRepository<Book> booksRepository;

        public BooksService(IDeletableEntityRepository<Book> booksRepository)
        {
            this.booksRepository = booksRepository;
        }

        public IEnumerable<BookSimpleViewModel> GetAllBooks()
        {
            // TODO: Mapping
            var allBooks = this.booksRepository.All()
                .Select(x => new BookSimpleViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    AuthorName = x.Author.FirstName + " " + x.Author.LastName,
                    Description = x.Description,
                    Price = x.Price,
                    PromotionPercentage = x.PromotionPercentage,
                    InStock = x.InStock,
                    PictureUrl = x.PictureUrl,
                })
                .ToList();

            return allBooks;
        }

        public BookDetailsViewModel GetBookById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookSimpleViewModel> GetBooksByCategoryId(int categoryId)
        {
            // TODO: Mapping
            var allBooksByCategoryId = this.booksRepository.All()
                .Where(x => x.CategoryId == categoryId)
                .Select(x => new BookSimpleViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    AuthorName = x.Author.FirstName + " " + x.Author.LastName,
                    Description = x.Description,
                    Price = x.Price,
                    PromotionPercentage = x.PromotionPercentage,
                    InStock = x.InStock,
                    PictureUrl = x.PictureUrl,
                })
                .ToList();

            return allBooksByCategoryId;
        }

        public IEnumerable<BookSimpleViewModel> GetBooksBySearchModel(BooksSearchModel searchModel)
        {
            var books = this.booksRepository.All().AsQueryable();

            if (searchModel != null)
            {
                // category
                if (searchModel.CategoryId.HasValue)
                {
                    books = books.Where(x => x.CategoryId == searchModel.CategoryId);
                }

                // language
                if (searchModel.SearchLang.HasValue)
                {
                    books = books.Where(x => x.LanguageId == searchModel.SearchLang);
                }

                // format
                if (searchModel.CoverFormat.HasValue)
                {
                    books = books.Where(x => x.BackCoverId == searchModel.CoverFormat);
                }

                // availability
                if (searchModel.InStock.HasValue)
                {
                    books = books.Where(x => x.InStock == searchModel.InStock);
                }

                // Price range
                if (!string.IsNullOrEmpty(searchModel.PriceRange))
                {
                    switch (searchModel.PriceRange)
                    {
                        case "low":
                            books = books.Where(x => x.Price < 15);
                            break;
                        case "med":
                            books = books.Where(x => (x.Price >= 15 && x.Price < 30));
                            break;
                        case "high":
                            books = books.Where(x => x.Price > 30);
                            break;
                        default:
                            break;
                    }
                }

                // Sort By
                if (!string.IsNullOrEmpty(searchModel.SearchSortBy))
                {
                    switch (searchModel.SearchSortBy)
                    {
                        case "name_ascending":
                            books = books.OrderBy(x => x.Title);
                            break;
                        case "name_descenting":
                            books = books.OrderByDescending(x => x.Title);
                            break;
                        case "price_low_high":
                            books = books.OrderBy(x => x.Price);
                            break;
                        case "price_high_low":
                            books = books.OrderByDescending(x => x.Price);
                            break;
                        case "pubdate_low_high":
                            books = books.OrderBy(x => x.Year);
                            break;
                        case "pubdate_high_low":
                            books = books.OrderByDescending(x => x.Year);
                            break;
                        default: // Name ascending
                            books = books.OrderBy(x => x.Title);
                            break;
                    }
                }

                if (searchModel.Page.HasValue)
                {

                }
            }

            return books.Select(x => new BookSimpleViewModel
            {
                Id = x.Id,
                Title = x.Title,
                AuthorName = x.Author.FirstName + " " + x.Author.LastName,
                Description = x.Description,
                Price = x.Price,
                PromotionPercentage = x.PromotionPercentage,
                InStock = x.InStock,
                PictureUrl = x.PictureUrl,
            })
            .ToList();
        }
    }
}
